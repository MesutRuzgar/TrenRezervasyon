using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrenRezervasyon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrenController : ControllerBase
    {
        ITrenService _trenService;

        public TrenController(ITrenService trenService)
        {
            _trenService = trenService;
        }
        [HttpGet("trenler")]
        public IActionResult Get()
        {
            var result = _trenService.Trenler();
            return Ok(result);
        }
    }
}
