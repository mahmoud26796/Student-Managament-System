using StudentManagamentSystem.Entities;

namespace StudentManagamentSystem.DTOs.TeacherDtos
{
    public record TeacherDto(
        string Frist_Name,
        string Last_Name,
        string Address,
        string Email,
        string Phone
    );
}