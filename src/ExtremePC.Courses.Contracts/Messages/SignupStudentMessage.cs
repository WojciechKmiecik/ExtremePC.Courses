using ExtremePC.Courses.Contracts.Interfaces;
using ExtremePC.Courses.Definition.Messaging;
using System;

namespace ExtremePC.Courses.Contracts.Messages
{
    public class SignupStudentMessage : IMessageGuid
    {
        // this could be base message... 
        public SignupStudentMessage()
        {
            Guid = Guid.NewGuid();
        }
        public Guid Guid { get; private set; }

        public long CourseId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Age { get; set; }
    }
}
