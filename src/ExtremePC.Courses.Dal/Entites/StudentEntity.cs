using ExtremePC.Courses.Dal.Entites.Abstract;
using System.Collections.Generic;

namespace ExtremePC.Courses.Dal.Entites
{
    internal class StudentEntity : PeopleEntity
    {
        public byte Age { get; set; }
        public ICollection<CourseStudentEntity> CourseStudents { get; set; }
    }
}
