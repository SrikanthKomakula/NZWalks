using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Helpers;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;
using System.Text;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewOneController : ControllerBase
    {
        public IRegionsRepository _regionsRepository;
        public InterviewOneController(IRegionsRepository regionsRepository)
        {
            _regionsRepository = regionsRepository;
        }

        [HttpGet]
        [Route("/isRegionsLengthEqual")]
        public async Task<IActionResult> IsRegionsLengthEqual([FromQuery] RegionCompareRequestDto regionCompareRequestDto)
        {
            var regionOneData = await _regionsRepository.getByGuidAsync(regionCompareRequestDto.regionGuid);
            var regionTwoData = await _regionsRepository.getByGuidAsync(regionCompareRequestDto.regionCompareGuid);
            //Here we used generic class so we are calling it with what type it should return (It is type independent)
            bool isEqual = MathComparisions<string>.isBothEqual(regionOneData.Code, regionTwoData.Code);

            return Ok(isEqual);
        }


        [HttpPost]
        [Route("/getCountOfEachCharacterInString")]
        public async Task<IActionResult> GetCountOfEachCharacterInString([FromBody] String textHere)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>(); // will return key value pair data

            foreach (char c in textHere)
            {
                if (charCount.ContainsKey(c)) charCount[c]++;
                else charCount[c] = 1;
            }

            return Ok(charCount);
        }

        [HttpPost]
        [Route("RemoveDuplicatesInString")]
        public IActionResult RemoveDuplicatesInString([FromBody]String textEntered)
        {
            var uniQueString = new HashSet<Char>(); // Will allows to contain only unique values

            var outPut = new StringBuilder(); //To create string object



            foreach(char c in textEntered)
            {
                if (uniQueString.Add(c))
                {
                    outPut.Append(c);
                }
            }

            return Ok(outPut.ToString());
        }


        [HttpPost]
        [Route("ReverseString")]
        public IActionResult ReverseString(string textEntered) {

            if (string.IsNullOrWhiteSpace(textEntered)) return Ok(textEntered);

            var words = textEntered.Split(' ');
            var reversedArray = new List<string>();
            foreach (var word in words) { 
                var charArray = word.ToCharArray();

                Array.Reverse(charArray);

                reversedArray.Add(new string(charArray));
            }

            return Ok(string.Join(" ", reversedArray));


        }

        [HttpPost]
        [Route("FirstNonRepeatingChar")]
        public IActionResult FirstNonRepeatingChar(string textEntered) {

            Dictionary<char, int> data = new Dictionary<char, int>();

            foreach(var e in textEntered)
            {
                if (data.ContainsKey(e))
                {
                    data[e] = data[e] + 1;
                }
                else
                {
                    data[e] = 1;
                }
            }
            foreach(var c in textEntered)
            {
                if (data[c] == 1)
                {
                    var firstUniquqChar = c;
                    return Ok(firstUniquqChar);
                }
            }
            return Ok("No unique characters");
        }
    }
}
