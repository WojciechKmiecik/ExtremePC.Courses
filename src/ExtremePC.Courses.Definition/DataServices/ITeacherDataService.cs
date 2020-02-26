using ExtremePC.Courses.Definition.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExtremePC.Courses.Definition.DataServices
{
    public interface ITeacherDataService
    {
        Task<TeacherModel> GetById(long id);
    }
}
