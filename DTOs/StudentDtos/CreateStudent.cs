using StudentManagamentSystem.Entities;

namespace StudentManagamentSystem.DTOs
{
    public record CreateStudent(
         string? First_Name,
         string? Last_Name,
         string Address,
         string Email,
         string Phone
    )
    {
        public static implicit operator CreateStudent(Student v)
        {
            throw new NotImplementedException();
        }
    }
}