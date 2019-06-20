using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCursos.Interfaces;

namespace WebApiCursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesProvider coursesProvider;

        public CoursesController(ICoursesProvider coursesProvider)
        {
            this.coursesProvider = coursesProvider;
        }
    }
}