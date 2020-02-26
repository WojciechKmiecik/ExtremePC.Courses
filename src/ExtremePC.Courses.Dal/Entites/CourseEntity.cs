using ExtremePC.Courses.Dal.Entites.Abstract;
using System.Collections.Generic;

namespace ExtremePC.Courses.Dal.Entites
{
    internal class CourseEntity : BaseEntity
    {
        public string Topic { get; set; }
        public ushort MaxCapacity { get; set; }
        public long TeacherId { get; set; }
        public TeacherEntity Teacher { get; set; }
        public ICollection<CourseStudentEntity> CourseStudents { get; set; }
    }
}
