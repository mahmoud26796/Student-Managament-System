using StudentManagamentSystem.Entities;

namespace StudentManagamentSystem.DTOs
{
    public record UpdateStudentDto(
         int Id,
         string First_Name,
         string Last_Name,
         string Address,
         string Email,
         string Phone,
         List<Course> Courses,
         List<string> Grades
    );
}