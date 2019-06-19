using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace helloworld.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration configuration;

        public string Mensaje { get; set; }

        public IndexModel(IConfiguration configuration)
        {
            this.configuration = configuration;
            Mensaje = configuration["mensaje"];
        }
        public void OnGet()
        {
        }
    }
}
