using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagamentSystem.Data;
using StudentManagamentSystem.DTOs.CourseDtos;
using StudentManagamentSystem.Entities;

namespace StudentManagamentSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController(IMapper mapper, AppDbContext appDbContext) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly AppDbContext _appDbContext = appDbContext;

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _appDbContext.Courses.ToListAsync();
            CourseDto courseDto;
            List<CourseDto> courseDtos = [];
            foreach (var course in courses)
            {
                courseDto = _mapper.Map<CourseDto>(course);
                courseDtos.Add(courseDto);
            }
            return Ok(courseDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _appDbContext.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (course is null)
            {
                return NotFound("Course Not Found!");
            }
            CourseDto courseDto = _mapper.Map<CourseDto>(course);
            return Ok(courseDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(Course newCourse)
        {

            var course = new Course
            {
                Name = newCourse.Name,
                Hours = newCourse.Hours
            };
            await _appDbContext.Courses.AddAsync(course);
            await _appDbContext.SaveChangesAsync();
            return CreatedAtRoute("GetById", new { id = course.Id }, course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, UpdateCourseDto updatedCourse)
        {
            var course = await _appDbContext.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (course is null)
            {
                return NotFound("Course Not Found!");
            }
            course.Name = updatedCourse.Name;
            course.Hours = updatedCourse.Hours;
            await _appDbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _appDbContext.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (course is null)
            {
                return NotFound("Course Not Found!");
            }
            _appDbContext.Courses.Remove(course);
            await _appDbContext.SaveChangesAsync();
            return NoContent();
        }

    }
}