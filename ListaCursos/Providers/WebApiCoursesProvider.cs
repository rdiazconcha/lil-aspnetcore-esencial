using ListaCursos.Interfaces;
using ListaCursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ListaCursos.Providers
{
    public class WebApiCoursesProvider : ICoursesProvider
    {
        private readonly IHttpClientFactory httpClientFactory;

        public WebApiCoursesProvider(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<(bool IsSuccess, int? Id)> AddAsync(Course course)
        {
            var client = httpClientFactory.CreateClient("coursesService");

            var body = new StringContent(JsonSerializer.ToString(course), System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/courses", body);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Parse<int?>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return (true, result);
            }

            return (false, null);
        }

        public async Task<ICollection<Course>> GetAllAsync()
        {
            var client = httpClientFactory.CreateClient("coursesService");

            var response = await client.GetAsync("api/courses");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Parse<ICollection<Course>>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return result;
            }

            return null;
        }

        public async Task<Course> GetAsync(int id)
        {
            var client = httpClientFactory.CreateClient("coursesService");
            var response = await client.GetAsync($"api/courses/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Parse<Course>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return result;
            }

            return null;
        }

        public async Task<ICollection<Course>> SearchAsync(string search)
        {
            var client = httpClientFactory.CreateClient("coursesService");

            var response = await client.GetAsync($"api/courses/search/{search}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Parse<ICollection<Course>>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return result;
            }

            return null;
        }

        public async Task<bool> UpdateAsync(int id, Course course)
        {
            var client = httpClientFactory.CreateClient("coursesService");

            var body = new StringContent(JsonSerializer.ToString(course), System.Text.Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"api/courses/{id}", body);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
