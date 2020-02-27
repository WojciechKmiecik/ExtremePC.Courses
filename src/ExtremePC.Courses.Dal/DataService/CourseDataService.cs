using ExtremePC.Courses.Dal.Context;
using ExtremePC.Courses.Dal.Entites;
using ExtremePC.Courses.Dal.Mappers;
using ExtremePC.Courses.Definition.DataServices;
using ExtremePC.Courses.Definition.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremePC.Courses.Dal.DataService
{

    internal class CourseDataService : ICourseDataService
    {
        private readonly CoursesDbContext _dbContext;

        public CourseDataService(CoursesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CourseModel> GetById(long id)
        {
            var e = await _dbContext.Courses.Include(x => x.CourseStudents).FirstOrDefaultAsync(x => x.Id == id);
            return e.Map();
        }

        // assumes that studententity is already in db
        public async Task<bool> AddStudentToCourse(long courseId, long studentId, string guid)
        {
            var c = await _dbContext.Courses.Include(x => x.CourseStudents).Where(x => x.Id == courseId).Select(x => x.Map()).FirstOrDefaultAsync();
            if (c.MaxCapacity <= c.CurrentCapacity)
            {
                return false;
            }
            var m = await _dbContext.CourseStudents.FirstOrDefaultAsync(x => x.CourseId == courseId && x.StudentId == studentId);
            if (m == null || m.Id < 1)
            {
                await _dbContext.CourseStudents.AddAsync(new CourseStudentEntity() { CourseId = courseId, StudentId = studentId, @Guid = guid }); ;
                var newId = await _dbContext.SaveChangesAsync();

            }
            else { return false; }
            return true;
        }

    }
}
