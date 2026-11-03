namespace StudentManagamentSystem.DTOs.TeacherDtos
{
    public record UpdateTeacherDto(
        int Id,
        string First_Name,
        string Last_Name,
        string Address,
        string Email,
        string Phone
    );
}