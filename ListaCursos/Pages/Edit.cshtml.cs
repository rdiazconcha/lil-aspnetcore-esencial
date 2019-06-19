using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaCursos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ListaCursos.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Course Course { get; set; }
        public void OnGet()
        {

        }
        public void OnPost()
        {
            //...
        }
    }
}