using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace TrenRezervasyon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezervasyonController : ControllerBase
    {
        IRezervasyonService _rezervasyonService;
      

        public RezervasyonController(IRezervasyonService rezervasyonService)
        {
            _rezervasyonService = rezervasyonService;
    
        }

        [HttpPost]
        public IActionResult RezervasyonSorgula(RezervasyonDTO p)
        {
                
                var result = _rezervasyonService.Kontrol(p);
                return Ok(result);
           
        }
     
    }
}
