using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagamentSystem.Data;
using StudentManagamentSystem.DTOs;
using StudentManagamentSystem.DTOs.StudentDtos;
using StudentManagamentSystem.Entities;

namespace StudentManagamentSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    class StudentController(AppDbContext appDbContext, IMapper mapper) : ControllerBase
    {
        private readonly AppDbContext _appDbContext = appDbContext;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _appDbContext.Students.ToListAsync();
            StudentDto studentDto;
            List<StudentDto> studentDtos = [];
            foreach (var student in students)
            {
                studentDto = _mapper.Map<StudentDto>(student);
                studentDtos.Add(studentDto);
            }
            return Ok(studentDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _appDbContext.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (student is null)
            {
                return NotFound("Student Not Found!");
            }
            var studentDto = _mapper.Map<StudentDto>(student);
            return Ok(studentDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentDto newStudent)
        {
            var student = new Student
            {
                First_Name = newStudent.First_Name,
                Last_Name = newStudent.Last_Name,
                Address = newStudent.Address,
                Email = newStudent.Email,
                Phone = newStudent.Phone
            };
            await _appDbContext.Students.AddAsync(student);
            await _appDbContext.SaveChangesAsync();
            return CreatedAtRoute("GetById", new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateStudentDto updatedStudent)
        {
            var student = await _appDbContext.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (student is null)
            {
                return NotFound("Student Not Found!");
            }
            student.First_Name = updatedStudent.First_Name;
            student.Last_Name = updatedStudent.Last_Name;
            student.Address = updatedStudent.Address;
            student.Email = updatedStudent.Email;
            student.Phone = updatedStudent.Phone;
            await _appDbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _appDbContext.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (student is null)
            {
                return NotFound("Student Not Found!");
            }
            _appDbContext.Students.Remove(student);
            await _appDbContext.SaveChangesAsync();
            return Ok();
        }

    }

}