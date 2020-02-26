using System;
using System.Collections.Generic;
using System.Text;

namespace ExtremePC.Courses.Definition.Models.Abstract
{
    public abstract class PeopleModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }        
    }
}
