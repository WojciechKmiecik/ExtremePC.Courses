using ExtremePC.Courses.Dal.Entites.Abstract;

namespace ExtremePC.Courses.Dal.Entites
{
    internal class CourseStudentEntity : BaseEntity
    {
        public int CourseId { get; set; }
        public CourseEntity Course { get; set; }
        public int StudentId { get; set; }
        public StudentEntity Student { get; set; }
        //optional, for checking the statuses
        //public string  Guid { get; set; }
    }
}
