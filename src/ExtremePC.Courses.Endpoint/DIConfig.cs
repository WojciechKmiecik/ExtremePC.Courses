using ExtremePC.Courses.Contracts.Interfaces;
using ExtremePC.Courses.Dal.Context;
using ExtremePC.Courses.Dal.DataService;
using ExtremePC.Courses.Definition.DataServices;
using ExtremePC.Courses.Definition.Messaging;
using ExtremePC.Courses.Endpoint.Handlers;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExtremePC.Courses.Endpoint
{
    public static class DIConfig
    {
        public static void ConfigureEndpointProducerServices(this IServiceCollection services)
        {
            
            services.AddScoped(provider => provider.GetRequiredService<IBus>().CreateRequestClient<ISignupRequested>());
            services.AddScoped<ISignupProducer, SignupProducer>();
        }
        public static void ConfigureEndpointConsumerServices(this IServiceCollection services, IConfiguration configuration)
        {

            //services.AddScoped(provider => provider.GetRequiredService<IBus>().CreateRequestClient<ISignupRequested>());
            //services.AddScoped<ISignupProducer, SignupProducer>();
        }
    }
}
