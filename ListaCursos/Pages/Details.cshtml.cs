using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaCursos.Interfaces;
using ListaCursos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ListaCursos.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ICoursesProvider coursesProvider;

        public Course Course { get; set; }

        public DetailsModel(ICoursesProvider coursesProvider)
        {
            this.coursesProvider = coursesProvider;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            var course = await coursesProvider.GetAsync(id);
            if (course != null)
            {
                Course = course;
                return Page();
            }

            return RedirectToPage("Courses");
        }
    }
}