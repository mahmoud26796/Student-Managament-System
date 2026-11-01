using AutoMapper;
using StudentManagamentSystem.DTOs.CourseDtos;
using StudentManagamentSystem.Entities;

namespace StudentManagamentSystem.Mappers
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
        }
    }
}