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
    public class EditModel : PageModel
    {
        private readonly ICoursesProvider coursesProvider;

        [BindProperty]
        public Course Course { get; set; }

        public EditModel(ICoursesProvider coursesProvider)
        {
            this.coursesProvider = coursesProvider;
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                Course = new Course();
            }
            else
            {
                var course = await coursesProvider.GetAsync(id.Value);
                if (course != null)
                {
                    Course = course;
                }
            }
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Course.Id == 0)
            {
                var result = await coursesProvider.AddAsync(Course);

                if (result.IsSuccess)
                {
                    return RedirectToPage("Courses");
                }

                return Page();
            }
            else
            {
                var result = await coursesProvider.UpdateAsync(Course.Id, Course);

                if (result)
                {
                    return RedirectToPage("Courses");
                }
            }

            return Page();
        }
    }
}