namespace StudentManagamentSystem.DTOs.CourseDtos
{
    public record UpdateCourseDto(
        int Id,
        string Name,
        int Hours
    );
}