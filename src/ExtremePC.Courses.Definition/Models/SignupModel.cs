using ExtremePC.Courses.Definition.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtremePC.Courses.Definition.Models
{
    public class SignupModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Age { get; set; }
    }
}
