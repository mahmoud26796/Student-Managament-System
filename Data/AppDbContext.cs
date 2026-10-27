using Microsoft.EntityFrameworkCore;
using StudentManagamentSystem.Entities;

namespace StudentManagamentSystem.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Teacher> Teachers => Set<Teacher>();

        public DbSet<Course> Courses => Set<Course>();

        public DbSet<Student> Students => Set<Student>();
    }


}