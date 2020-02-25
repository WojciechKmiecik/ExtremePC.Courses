using System.Collections.Generic;

namespace ExtremePC.Courses.Dal.Entites
{
    internal class CourseEntity
    {
        public string Topic { get; set; }
        public ushort MaxCapacity { get; set; }
        public int TeacherId { get; set; }
        public TeacherEntity Teacher { get; set; }
        public ICollection<CourseStudentEntity> CourseStudents { get; set; }
    }
}
