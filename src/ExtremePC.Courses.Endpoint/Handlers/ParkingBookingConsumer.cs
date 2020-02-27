using ExtremePC.Courses.Contracts.Interfaces;
using ExtremePC.Courses.Definition.Messaging;
using ExtremePC.Courses.Definition.Services;
using ExtremePC.Courses.Shared.Mapper;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExtremePC.Courses.Endpoint.Handlers
{
    public class ParkingBookingConsumer :
        IConsumer<ISignupRequested>, ISignupConsumer
    {
        private readonly ISignupService _signupService;

        public ParkingBookingConsumer(ISignupService signupService)
        {
            _signupService = signupService;
        }

        public async Task Consume(ConsumeContext<ISignupRequested> context)
        {
            
            var mappedVal = context.Message.SignupStudent.Map();
            var serviceResponse = await _signupService.SignupStudentToCourseAsync(mappedVal.Item1,mappedVal.Item2);            

            await context.RespondAsync<ISignupProcessed>(new
            {
                Result = serviceResponse.Item1,
                Message = serviceResponse.Item2
            });
            // respond or send mail or use signalR. 

        }
    }
}
