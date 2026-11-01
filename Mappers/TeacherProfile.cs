using AutoMapper;
using StudentManagamentSystem.DTOs.TeacherDtos;
using StudentManagamentSystem.Entities;

namespace StudentManagamentSystem.Mappers
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherDto>().ReverseMap();
        }
    }
}