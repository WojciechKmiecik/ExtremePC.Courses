using ExtremePC.Courses.Definition.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExtremePC.Courses.Definition.DataServices
{
    public interface ICourseDataService
    {
        Task<bool> AddStudentToCourse(long courseId, long studentId, string guid);
        Task<CourseModel> GetById(long id);
    }
}
