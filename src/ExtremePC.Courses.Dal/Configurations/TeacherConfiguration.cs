using ExtremePC.Courses.Dal.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExtremePC.Courses.Dal.Configurations
{
    internal class TeacherConfiguration : IEntityTypeConfiguration<TeacherEntity>
    {
        public void Configure(EntityTypeBuilder<TeacherEntity> builder)
        {
            builder.ToTable("Teachers");

            builder.HasData(new TeacherEntity() { Id = 1, FirstName = "Mr Teacher", LastName = "Test" });
            builder.HasData(new TeacherEntity() { Id = 2, FirstName = "Mr Programmer", LastName = "Teacher" });
        }
    }
}
