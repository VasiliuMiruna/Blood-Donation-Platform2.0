using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect4.blood_donation_backend_BLL.Interfaces;
using Proiect4.blood_donation_backend_BLL.Models;

namespace Proiect4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [Authorize(Roles = "Admin,Doctor")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TestModel test)
        {
            await _testService.Create(test);
            return Ok(test);
        }

        [Authorize(Roles = "Admin, Donor")]
        [HttpGet]
        public async Task<List<Guid>> GetAllPositives()
        {
            var list = await _testService.GetPositives();
            return list;
        }
        
       
    }
}
