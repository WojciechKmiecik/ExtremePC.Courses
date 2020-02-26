using ExtremePC.Courses.Definition.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExtremePC.Courses.Definition.DataServices
{
    public interface IStudentDataService
    {
        Task<StudentModel> AddNonExisting(StudentModel model);
        Task<List<StudentModel>> GetAllByName(List<StudentModel> students);
        Task<StudentModel> GetByData(StudentModel model);
        Task<StudentModel> GetById(long id);
    }
}
