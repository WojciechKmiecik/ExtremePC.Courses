using ExtremePC.Courses.Contracts.Interfaces;
using ExtremePC.Courses.Endpoint;
using ExtremePC.Courses.Endpoint.BusService;
using ExtremePC.Courses.Endpoint.Handlers;
using ExtremePC.Courses.Shared;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ExtremePC.Courses.WebApi.Configuration
{
    public static class MassTransitConfiguration
    {
        public static void ConfigureMassTransitSerivce(this IServiceCollection services)
        {
            services.AddSingleton(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                // should come from config ..
                var host = cfg.Host("localhost", "/", h => { });

                cfg.UseExtensionsLogging(provider.GetService<ILoggerFactory>());

                cfg.ReceiveEndpoint(Constants.QueueNames.SignupStudentQueue, e =>
                {
                    e.PrefetchCount = 16;
                    // 

                    //e.AddConsumersFromNamespaceContaining<UpdateCustomerAddressConsumer>()
                    e.Consumer<ParkingBookingConsumer>(provider);

                    EndpointConvention.Map<ISignupRequested>(e.InputAddress);
                });
            }));
            services.AddSingleton<IPublishEndpoint>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<ISendEndpointProvider>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());

            //should be by namespace
            services.ConfigureEndpointProducerServices();

            services.AddSingleton<IHostedService, BusService>();
        }

        public static void ConfigureMassTransit(this IApplicationBuilder app)
        {

        }
    }
}
