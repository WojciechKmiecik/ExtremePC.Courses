namespace ExtremePC.Courses.Dal.Entites
{
    internal class CourseStudentEntity
    {
        public int CourseId { get; set; }
        public CourseEntity Course { get; set; }
        public int StudentId { get; set; }
        public StudentEntity Student { get; set; }
    }
}
