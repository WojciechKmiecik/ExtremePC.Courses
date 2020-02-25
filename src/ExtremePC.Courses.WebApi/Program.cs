using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;
using System.Reflection;

namespace ExtremePC.Courses.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var docFile = $"{Assembly.GetEntryAssembly().GetName().Name}.txt";
            var filePath = Path.Combine(AppContext.BaseDirectory,@"\Log\", docFile);

            Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .MinimumLevel.Debug().WriteTo.RollingFile(filePath, retainedFileCountLimit: 7).WriteTo.Console().CreateLogger();

            try
            {
                Log.Information("Starting up");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
