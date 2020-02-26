using ExtremePC.Courses.Dal.Context;
using ExtremePC.Courses.Dal.Mappers;
using ExtremePC.Courses.Definition.DataServices;
using ExtremePC.Courses.Definition.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExtremePC.Courses.Dal.DataService
{ 

    internal class TeacherDataService : ITeacherDataService
    {
        private readonly CoursesDbContext _dbContext;

        public TeacherDataService(CoursesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TeacherModel> GetById(long id)
        {
            var e = await _dbContext.Teachers.FirstOrDefaultAsync(x => x.Id == id);
            return e.Map();
        }
    }
}
