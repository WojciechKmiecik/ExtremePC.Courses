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
    internal class StudentDataService : IStudentDataService
    {
        private readonly CoursesDbContext _dbContext;

        public StudentDataService(CoursesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<StudentModel> GetById(long id)
        {
            var e = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            return e.Map();
        }

        public async Task<StudentModel> GetByData(StudentModel model)
        {
            //somehow id does not work in EF Core?! 
            // querry could not be translated. Either rewrite the query in a form that can be translated, or switch to client evaluation explicitly by inserting a call to either

            //var e = await _dbContext.Students.FirstOrDefaultAsync(x => x.FirstName.Equals(model.FirstName.Trim(), StringComparison.OrdinalIgnoreCase) &&
            //                                                           x.LastName.Equals(model.LastName.Trim(), StringComparison.OrdinalIgnoreCase) &&
            //                                                           (model.Age == x.Age || model.Age == x.Age + 1));  // someone get older, i dont have better identifier
            var e = (await _dbContext.Students.ToListAsync()).FirstOrDefault(x => x.FirstName.Equals(model.FirstName.Trim(), StringComparison.OrdinalIgnoreCase) &&
                                                                       x.LastName.Equals(model.LastName.Trim(), StringComparison.OrdinalIgnoreCase) &&
                                                                       (model.Age == x.Age || model.Age == x.Age + 1));  // someone get older, i dont have better identifier
            return e.Map();
        }
        public async Task<List<StudentModel>> GetAllByName(List<StudentModel> students)
        {
            IQueryable<StudentEntity> query = _dbContext.Students;
            foreach (var student in students)
            {
                query = query.Where(x => x.FirstName.Equals(student.FirstName.Trim(), StringComparison.OrdinalIgnoreCase) &&
                                    x.LastName.Equals(student.LastName.Trim(), StringComparison.OrdinalIgnoreCase));
            }
            var el = await query.Select(x => x.Map()).ToListAsync();
            return el;
        }
        public async Task<StudentModel> AddNonExisting(StudentModel model)
        {
            var m = await GetByData(model);
            if (m.Id < 1)
            {
                await _dbContext.Students.AddAsync(model.Map());
                var newId = await _dbContext.SaveChangesAsync();
                m = await GetById(newId);
            }
            return m;
        }

    }
}
