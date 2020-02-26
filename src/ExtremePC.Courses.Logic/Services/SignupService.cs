using ExtremePC.Courses.Dal.Mappers;
using ExtremePC.Courses.Definition.DataServices;
using ExtremePC.Courses.Definition.Models;
using ExtremePC.Courses.Definition.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExtremePC.Courses.Logic.Services
{
    public class SignupService : ISignupService
    {
        private readonly IStudentDataService _studentData;
        private readonly ICourseDataService _courseData;
        private readonly ITeacherDataService _teacherData;
        private readonly object addStudentLock = new object();
        public SignupService(IStudentDataService studentData, ICourseDataService courseData, ITeacherDataService teacherData)
        {
            _studentData = studentData;
            _courseData = courseData;
            _teacherData = teacherData;
        }
        // should be generic response object with Data, errors and Warnigns
        public async Task<ValueTuple<bool, string>> SignupStudentToCourseAsync(SignupModel model, string guid = "")
        {
            // thing about better error handling, generally
            var course = await _courseData.GetById(model.Id);
            if (course == null || course.Id < 1)
            {
                // thing about constant message values or put htis to resx file , for translation purposees
                return (false, "Course do not exists");
            }
            //firstly add the student, for marketing purposes. even if course would be full then alter we can send him an e-mail about course
            var student = await _studentData.AddNonExisting(model.Map());
            //
            lock (addStudentLock)
            {
                if (course.CurrentCapacity >= course.MaxCapacity)
                {
                    return (false, "course is full");
                }

            }
            var result = await _courseData.AddStudentToCourse(course.Id, student.Id, guid);
            if (result)
            {
                return (result, "Student Added successfuly");
            }
            else
            {
                return (result, "cannot add student");
            }

        }
    }
}
