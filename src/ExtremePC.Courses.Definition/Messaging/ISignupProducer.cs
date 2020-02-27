using ExtremePC.Courses.Contracts.Messages;
using ExtremePC.Courses.Definition.Messaging.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExtremePC.Courses.Definition.Messaging
{
    public interface ISignupProducer : IMassTransitProducer
    {
        Task<bool> SendRequest(SignupStudentMessage signupStudentMessage);
    }
}
