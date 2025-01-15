using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Bogus.DataSets;
using Domain.Contracts;
using Domain.Models.Entities;
using LMS.Infrastructure.Data;
using LMS.Shared.DTOs;
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

        private readonly LmsContext dbContext;

        private readonly IMapper _mapper;

        public CoursesController(LmsContext context, IMapper mapper)
        {
            dbContext = context;
            _mapper = mapper;
        }

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
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetAllCourses()
        {
            var courses = await dbContext.Courses.ToListAsync();

            if (courses == null)
            {
                return NotFound(new { Message = $"Courses not found." });
            }

            var coursesDtos = _mapper.Map<IEnumerable<CourseDto>>(courses);

            // Return all courses
            return Ok(coursesDtos);
        }
    }
}
