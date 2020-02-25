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
        }
    }
}
