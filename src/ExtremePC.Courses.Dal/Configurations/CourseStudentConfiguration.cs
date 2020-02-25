using ExtremePC.Courses.Dal.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExtremePC.Courses.Dal.Configurations
{
    internal class CourseStudentConfiguration : IEntityTypeConfiguration<CourseStudentEntity>
    {
        public void Configure(EntityTypeBuilder<CourseStudentEntity> builder)
        {
            builder.HasKey(cs => new { cs.CourseId, cs.StudentId });

            builder
                .HasOne(cs => cs.Course)
                .WithMany(c => c.CourseStudents)
                .HasForeignKey(cs => cs.CourseId);

            builder
                .HasOne(cs => cs.Student)
                .WithMany(s => s.CourseStudents)
                .HasForeignKey(cs => cs.StudentId);

            builder.ToTable("CourseStudents");
        }
    }
}
