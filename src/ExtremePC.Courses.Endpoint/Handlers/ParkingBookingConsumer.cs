using ExtremePC.Courses.Contracts.Interfaces;
using ExtremePC.Courses.Definition.Messaging;
using ExtremePC.Courses.Definition.Services;
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
            var serviceResponse = await _signupService.SignupStudentToCourseAsync(context.Message?.SignupStudent.Map(), context.Message?.SignupStudent?.Guid.ToString());
            //var serviceResponse = await _bookingService.PostNewBooking(context.Message.BookingModel);

            await context.RespondAsync<ISignupProcessed>(new
            {
                Message = serviceResponse
            });
            // respond or send mail or use signalR. 

        }
    }
}
