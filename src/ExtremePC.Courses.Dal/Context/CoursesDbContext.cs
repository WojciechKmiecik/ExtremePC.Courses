using ExtremePC.Courses.Dal.Configurations;
using ExtremePC.Courses.Dal.Entites;
using Microsoft.EntityFrameworkCore;

namespace ExtremePC.Courses.Dal.Context
{
    internal class CoursesDbContext : BaseDbContext
    {
        private static bool created = false;
        public CoursesDbContext(DbContextOptions<CoursesDbContext> options) : base(options)
        {
            if (!created)
            {
                Database.EnsureCreated();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new CourseStudentConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());



        }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<TeacherEntity> Teachers { get; set; }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<CourseStudentEntity> CourseStudents { get; set; }
    }
}
