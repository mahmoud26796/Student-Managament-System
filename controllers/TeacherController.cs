using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagamentSystem.Data;
using StudentManagamentSystem.DTOs.TeacherDtos;
using StudentManagamentSystem.Entities;

namespace StudentManagamentSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController(Mapper mapper, AppDbContext appDbContext) : Controller
    {
        private readonly Mapper _mapper = mapper;
        private readonly AppDbContext _appDbContext = appDbContext;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teachers = await _appDbContext.Teachers.ToListAsync();
            TeacherDto teacherDto;
            List<TeacherDto> teacherDtos = [];
            foreach (var teacher in teachers)
            {
                teacherDto = _mapper.Map<TeacherDto>(teacher);
                teacherDtos.Add(teacherDto);
            }
            return Ok(teacherDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var teacher = await _appDbContext.Teachers.FirstOrDefaultAsync(t => t.Id == id);
            if (teacher is null)
            {
                return NotFound("Teacher Not Found!");
            }
            return Ok(teacher);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Teacher newTeacher)
        {
            var teacher = new Teacher
            {
                First_Name = newTeacher.First_Name,
                Last_Name = newTeacher.Last_Name,
                Address = newTeacher.Address,
                Email = newTeacher.Email,
                Phone = newTeacher.Phone
            };
            await _appDbContext.Teachers.AddAsync(teacher);
            await _appDbContext.SaveChangesAsync();
            return CreatedAtRoute("GetById", new { id = teacher.Id }, teacher);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(int id, UpdateTeacherDto updatedTeacher)
        {
            var teacher = await _appDbContext.Teachers.FirstOrDefaultAsync(t => t.Id == id);
            if (teacher is null)
            {
                return NotFound("Teacher Not Found!");
            }
            teacher.First_Name = updatedTeacher.First_Name;
            teacher.Last_Name = updatedTeacher.Last_Name;
            teacher.Address = updatedTeacher.Address;
            teacher.Email = updatedTeacher.Email;
            teacher.Phone = updatedTeacher.Phone;
            await _appDbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var teacher = await _appDbContext.Teachers.FirstOrDefaultAsync(t => t.Id == id);
            if (teacher is null)
            {
                return NotFound("Teacher Not Found!");
            }
            _appDbContext.Teachers.Remove(teacher);
            await _appDbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}