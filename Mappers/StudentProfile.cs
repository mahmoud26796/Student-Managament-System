using AutoMapper;
using StudentManagamentSystem.DTOs.StudentDtos;
using StudentManagamentSystem.Entities;

namespace StudentManagamentSystem.Mappers
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}