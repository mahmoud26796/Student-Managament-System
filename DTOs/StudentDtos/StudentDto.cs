using StudentManagamentSystem.Entities;

namespace StudentManagamentSystem.DTOs
{
    public record StudentDto(
        string First_Name,
         string Last_Name,
         string Address,
         string Email,
         string Phone
    )
    {
        public static implicit operator StudentDto(Student v)
        {
            throw new NotImplementedException();
        }
    }
}