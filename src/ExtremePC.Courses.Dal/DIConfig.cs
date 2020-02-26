using ExtremePC.Courses.Dal.Context;
using ExtremePC.Courses.Dal.DataService;
using ExtremePC.Courses.Definition.DataServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExtremePC.Courses.Dal
{
    public static class DIConfig
    {
        public static void ConfigureDalServices(this IServiceCollection services, IConfiguration configuration)
        {
            //(Alternative: DbContext using a SQL Server provider
            services.AddDbContext<CoursesDbContext>(c =>
            {
                c.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<ITeacherDataService, TeacherDataService>();
            services.AddScoped<IStudentDataService, StudentDataService>();
            services.AddScoped<ICourseDataService, CourseDataService>();

        }
    }
}
