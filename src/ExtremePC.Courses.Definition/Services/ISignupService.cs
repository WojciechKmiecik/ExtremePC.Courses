using ExtremePC.Courses.Definition.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExtremePC.Courses.Definition.Services
{
    public interface ISignupService
    {
        Task<ValueTuple<bool, string>> SignupStudentToCourseAsync(SignupModel model, string guid = "");
    }
}
