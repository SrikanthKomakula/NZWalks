using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //dfg
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;
        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }
        // api/Auth/Register
        //param: RegisterRequestDro
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.UserName,
                Email = registerRequestDto.UserName
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);
            if (identityResult.Succeeded)
            {
                var roleResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                if (roleResult.Succeeded)
                {
                    return Ok("User Registerd!, Please Login.");
                }
            }
            return BadRequest("Something Went Wrong");
        }

        //Login methond
        //loginRequestDto
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.UserName);

            if (user != null)
            {

                var checkPassword = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);
                if (checkPassword)
                {
                    // get roles
                    var roles = await userManager.GetRolesAsync(user);


                        if(roles != null)
                        {
                        var token = tokenRepository.CreateJWTToken(user, roles.ToList());
                        var response = new LoginResponseDto
                        {
                            jwtToken = token
                        };
                        return Ok(response);
                        }
                }

            }
            return BadRequest("Email or Password are incorrect");
        }
    }
}
