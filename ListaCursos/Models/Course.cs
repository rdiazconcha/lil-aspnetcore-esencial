using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListaCursos.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(500, ErrorMessage = "El número máximo de caracteres permitidos es 500")]
        public string Description { get; set; }

        [Display(Name = "Autor(a)")]
        [Required(ErrorMessage = "El(la) autor(a) es requerido(a)")]
        public string Author { get; set; }

        [Display(Name = "Dirección del curso")]
        [Url(ErrorMessage = "La dirección no es válida")]
        public string Uri { get; set; }
    }
}
