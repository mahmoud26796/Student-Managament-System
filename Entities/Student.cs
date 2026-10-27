using System.ComponentModel.DataAnnotations;

namespace StudentManagamentSystem.Entities
{
    public class Student
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
        public string? Email { get; set; }
        [Required]
        [StringLength(20)]
        public string? Phone { get; set; }

        [Required]
        public List<Course>? Courses { get; set; }

        [Required]
        public List<string>? Grades { get; set; }

    }
}