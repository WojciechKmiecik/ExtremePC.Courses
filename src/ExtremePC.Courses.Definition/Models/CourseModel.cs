using ExtremePC.Courses.Definition.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtremePC.Courses.Definition.Models
{
    public class CourseModel : BaseModel
    {
        public CourseModel()
        {
            Students = new List<StudentModel>();
        }
        public string Topic { get; set; }
        public ushort MaxCapacity { get; set; }
        public long TeacherId { get; set; }
        public string TeacherName { get; set; }
        public List<StudentModel> Students { get; set; }
    }
}
