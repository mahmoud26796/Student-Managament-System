
using System.ComponentModel.DataAnnotations;
using StudentManagamentSystem.DTOs.TeacherDtos;

namespace StudentManagamentSystem.Entities
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? First_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string? Last_Name { get; set; }
        [Required]
        [StringLength(50)]
        public string? Address { get; set; }
        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [StringLength(20)]
        public string? Phone { get; set; }

        [Required]
        public ICollection<Course>? Courses { get; set; } = [];

        public static implicit operator Teacher(TeacherDto v)
        {
            throw new NotImplementedException();
        }
    }

}
