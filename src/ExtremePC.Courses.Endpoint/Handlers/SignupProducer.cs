using ExtremePC.Courses.Contracts.Interfaces;
using ExtremePC.Courses.Contracts.Messages;
using ExtremePC.Courses.Definition.Messaging;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExtremePC.Courses.Endpoint.Handlers
{
    public class SignupProducer : ISignupProducer
    {
        private readonly IRequestClient<ISignupRequested> _requestClient;

        public SignupProducer(IRequestClient<ISignupRequested> requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task SendRequest(SignupStudentMessage signupStudentMessage)
        {
            _requestClient.Create(new { SignupStudent = signupStudentMessage });
            await Task.CompletedTask;
        }

    }
}
