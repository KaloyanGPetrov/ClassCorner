using Microsoft.EntityFrameworkCore;

namespace ClassCorner.Models
{
    public class ClassCorner_DbContext:DbContext
    {
        public ClassCorner_DbContext(DbContextOptions options) : base(options) 
        {
            
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Assigment> Assigments { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Homework> Homework { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAssigment> StudentAssigments { get;set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherClass> TeacherClasses { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
    }
}
