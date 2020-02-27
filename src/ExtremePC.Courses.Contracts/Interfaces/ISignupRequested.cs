using ExtremePC.Courses.Contracts.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtremePC.Courses.Contracts.Interfaces
{
    public interface ISignupRequested
    {
        SignupStudentMessage SignupStudent { get; set; }
    }
}
