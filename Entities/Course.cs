using System.ComponentModel.DataAnnotations;

namespace StudentManagamentSystem.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public int Name { get; set; }

        [Required]
        public int Hourse { get; set; }

        [Required]
        public List<Student>? Students { get; set; }
    }

}