using Microsoft.AspNetCore.Mvc;
using NZWalks.UI.Models.DTOs;
using System.Collections.Generic;

namespace NZWalks.UI.Controllers
{
    public class WalksController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public WalksController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {

            List<WalkDTO> walksDto = new List<WalkDTO>();

            try
            {
                var client = httpClientFactory.CreateClient();

                var walksRes = await client.GetAsync("https://localhost:7277/api/Walks");

                walksRes.EnsureSuccessStatusCode();


                walksDto.AddRange(await walksRes.Content.ReadFromJsonAsync<IEnumerable<WalkDTO>>());


            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return View(walksDto);
        }


        [HttpGet]

        public IActionResult Add()
        {
            return View();
        }





    }
}
