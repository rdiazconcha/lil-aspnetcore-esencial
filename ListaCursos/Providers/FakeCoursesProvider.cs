using ListaCursos.Interfaces;
using ListaCursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaCursos.Providers
{
    public class FakeCoursesProvider : ICoursesProvider
    {
        private readonly List<Course> repo = new List<Course>();

        public FakeCoursesProvider()
        {
            repo.Add(new Course()
            {
                Id = 1,
                Name = "Azure DevOps y VSTS esencial",
                Author = "Rodrigo Díaz Concha",
                Description = "Conoce los principios, herramientas y técnicas de Azure DevOps y Visual Studio .NET. Amplia y mejora tus conocimientos sobre Azure Repos, Azure Pipelines, Azure Boards, Azure Test Plans y Azure Artifacts. Consigue entregar software de mejor calidad en menos tiempo y asegura un desarrollo exitoso en proyectos de cualquier tipo de tamaño.",
                Uri = "https://www.linkedin.com/learning/azure-devops-y-vsts-esencial"
            });
            repo.Add(new Course()
            {
                Id = 2,
                Name = "Azure Functions esencial",
                Author = "Rodrigo Díaz Concha",
                Description = "Aprende Azure Functions como tecnología y plataforma de desarrollo de aplicaciones. Conoce cuáles son los beneficios de una arquitectura Serverless y sus características. Domina el desarrollo desde Visual Studio .NET y sus conceptos clave: cómo se monitoriza, cómo se despliega, qué son los Triggers o los Bindings o cómo hacer depuración y pruebas, entre otros conocimientos esenciales.",
                Uri = "https://www.linkedin.com/learning/azure-functions-esencial"
            });
            repo.Add(new Course()
            {
                Id = 3,
                Name = "Azure: Internet de las cosas esencial",
                Author = "Rodrigo Díaz Concha",
                Description = "Descubre Microsoft Azure para el envío y recepción de mensajes hacia y desde dispositivos Internet of Things. Conoce y domina todos los conceptos fundamentales de Azure IoT Solution Accelerators y Azure IoT Central, las piezas clave en las soluciones de Microsoft para IoT, y que se presentan como opciones Software-As-A-Service (SaaS) para la creación, implementación y administración de soluciones IoT de una forma rápida y sencilla.",
                Uri = "https://www.linkedin.com/learning/azure-internet-de-las-cosas-esencial"
            });
        }

        public Task<(bool IsSuccess, int? Id)> AddAsync(Course course)
        {
            course.Id = repo.Max(c => c.Id) + 1;
            repo.Add(course);
            return Task.FromResult((true, (int?)course.Id));
        }

        public Task<ICollection<Course>> GetAllAsync()
        {
            return Task.FromResult((ICollection<Course>)repo.ToList());
        }

        public Task<Course> GetAsync(int id)
        {
            return Task.FromResult(repo.FirstOrDefault(c => c.Id == id));
        }

        public Task<ICollection<Course>> SearchAsync(string search)
        {
            return Task.FromResult((ICollection<Course>)repo.Where(c=>c.Name.ToLowerInvariant().Contains(search.ToLowerInvariant())).ToList());
        }

        public Task<bool> UpdateAsync(int id, Course course)
        {
            var courseToUpdate = repo.FirstOrDefault(c => c.Id == id);
            if (courseToUpdate != null)
            {
                courseToUpdate.Name = course.Name;
                courseToUpdate.Description = course.Description;
                courseToUpdate.Author = course.Author;
                courseToUpdate.Uri = course.Uri;

                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
