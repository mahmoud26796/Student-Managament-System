namespace StudentManagamentSystem.DTOs
{
    public record GetStudent(
        string? First_Name,
         string? Last_Name,
         string Address,
         string Email,
         string Phone
    );
}