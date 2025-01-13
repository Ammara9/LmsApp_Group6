using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models.Entities;
using LMS.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS.Presemtation.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        private static List<Course> courses = new List<Course>();
        private static int nextId = 1;

        [HttpPost]
        public IActionResult AddCourse([FromBody] Course newCourse)
        {
            if (newCourse == null)
            {
                return BadRequest("Course is null.");
            }

            newCourse.Id = nextId++;
            courses.Add(newCourse);
            return Ok(newCourse);
        }

        [HttpGet("{id}")]
        public IActionResult GetCourse(int id)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpGet]
        public IActionResult GetAllCourses()
        {
            // Return all courses
            return Ok(courses);
        }
    }
}
