using ExtremePC.Courses.Dal.Entites.Abstract;
using System.Collections.Generic;

namespace ExtremePC.Courses.Dal.Entites
{
    internal class TeacherEntity : PeopleEntity
    {
        public ICollection<CourseEntity> Courses { get; set; }
    }
}
