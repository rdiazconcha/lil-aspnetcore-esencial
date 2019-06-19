using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaCursos.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Uri { get; set; }
    }
}
