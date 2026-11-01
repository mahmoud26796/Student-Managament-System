using AutoMapper;
using StudentManagamentSystem.DTOs;
using StudentManagamentSystem.Entities;

namespace StudentManagamentSystem.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}