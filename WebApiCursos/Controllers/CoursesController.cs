using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCursos.Interfaces;
using WebApiCursos.Models;

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

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var results = await coursesProvider.GetAllAsync();
            if (results != null)
            {
                return Ok(results);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await coursesProvider.GetAsync(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound(id);
        }

        [HttpGet("search/{search}")]
        public async Task<IActionResult> SearchAsync(string search)
        {
            var results = await coursesProvider.SearchAsync(search);
            
            if (results != null)
            {
                return Ok(results);
            }

            return NotFound(search);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Course course)
        {
            if (course == null)
            {
                return BadRequest();
            }

            var result = await coursesProvider.AddAsync(course);
            if (result.IsSuccess)
            {
                return Ok(result.Id);
            }

            return NotFound();
        }

        [HttpPut("{id}")] //api/courses/1
        public async Task<IActionResult> UpdateAsync(int id, Course course)
        {
            var result = await coursesProvider.UpdateAsync(id, course);
            if (result)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}