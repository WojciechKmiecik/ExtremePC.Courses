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


            // could be loaded from configuration
            builder.HasData(new CourseEntity() { Id = 1, MaxCapacity = 5, TeacherId = 1, Topic = "Small Capacity Course" });
            builder.HasData(new CourseEntity() { Id = 2, MaxCapacity = 20, TeacherId = 2, Topic = "Frontend Course" });
            builder.HasData(new CourseEntity() { Id = 3, MaxCapacity = 200, TeacherId = 2, Topic = "Backend Course" });
        }
    }
}
