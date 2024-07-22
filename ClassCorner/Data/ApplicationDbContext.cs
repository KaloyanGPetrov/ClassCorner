using ClassCorner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClassCorner.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set;}
        public DbSet<Class> Classes { get; set;}
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Assigment> Assigments { get; set; }
        public DbSet<Homework> Homework { get; set; }
        public DbSet<StudentAssigment> StudentAssigments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherClass> TeacherClasses { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }

    }
}
