using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiCursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        [HttpGet("{number}")]
        public IActionResult Get(int number)
        {
            if (number < 100)
            {
                return Ok(number);
            }

            return NotFound(number);
        }
    }
}