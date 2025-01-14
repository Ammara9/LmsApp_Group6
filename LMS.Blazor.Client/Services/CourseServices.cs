using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Domain.Models.Entities;
using LMS.Shared.DTOs;

namespace LMS.Blazor.Client.Services
{
    public class CourseServices
    {
        private readonly HttpClient _httpClient;

        public CourseServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Course>?> GetCoursesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Course>>("api/courses");
        }

        public async Task<Course?> GetCourseAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Course>($"api/courses/{id}");
        }

        public async Task AddCourseAsync(CourseDto courseDto)
        {
            // Map CourseDto to Course domain model
            var course = new Course
            {
                CourseName = courseDto.CourseName,
                CourseDescription = courseDto.CourseDescription,
                StartDate = courseDto.StartDate,
            };

            await _httpClient.PostAsJsonAsync("api/courses", course);
        }

        public async Task UpdateCourseAsync(Course course)
        {
            await _httpClient.PutAsJsonAsync($"api/courses/{course.Id}", course);
        }

        public async Task DeleteCourseAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/courses/{id}");
        }
    }
}
