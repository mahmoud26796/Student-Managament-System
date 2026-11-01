using AutoMapper;
using StudentManagamentSystem.DTOs;
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