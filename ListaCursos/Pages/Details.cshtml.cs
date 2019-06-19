using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaCursos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ListaCursos.Pages
{
    public class DetailsModel : PageModel
    {
        public Course Course { get; set; }

        public void OnGet()
        {
            Course = new Course();
        }
    }
}