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
        public void OnGet()
        {

        }
        public void OnPost()
        {
            //... coursesProvider....
        }
    }
}