using Microsoft.AspNetCore.Mvc;
using Sharper.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharper.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        ITestServiceOne _testServiceOne;
        ITestServiceTwo _testServiceTwo;
        public TestController(ITestServiceOne testServiceOne, ITestServiceTwo testServiceTwo)
        {
            _testServiceOne = testServiceOne;
            _testServiceTwo = testServiceTwo;
        }

        [HttpGet]
        public async Task<string> GetOne()
        {
            await _testServiceOne.FirstMethod();
            return "GetOne Success";
        }

        [HttpGet]
        public async Task<string> GetTwo()
        {
            await _testServiceTwo.FirstMethod();

            return "GetTwo Success";
        }
    }
}
