using System;
using System.Collections.Generic;
using System.Text;

namespace ExtremePC.Courses.Definition.Models
{
    public class CourseModel
    {
        public long Id { get; set; }
        public string Topic { get; set; }
        public ushort MaxCapacity { get; set; }
        
    }
}
