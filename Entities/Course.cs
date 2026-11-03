using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagamentSystem.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        public int Hours { get; set; }

        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }

        public Teacher? Teacher { get; set; }

        [Required]
        public ICollection<Student>? Students { get; set; } = [];
    }

}