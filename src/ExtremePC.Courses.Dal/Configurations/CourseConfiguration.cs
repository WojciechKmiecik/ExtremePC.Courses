using ExtremePC.Courses.Dal.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExtremePC.Courses.Dal.Configurations
{
    internal class CourseConfiguration : IEntityTypeConfiguration<CourseEntity>
    {
        public void Configure(EntityTypeBuilder<CourseEntity> builder)
        {
            builder.HasOne(c => c.Teacher)
                .WithMany(t => t.Courses);
            builder.ToTable("Courses");
        }
    }
}
