using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace CS301_Spend_Transactions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // Add Serilog for better loggin diagnostics
        // For more reference: https://nblumhardt.com/2019/10/serilog-in-aspnetcore-3/ 
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup<Startup>()
                        .UseSerilog((hostingContext, loggerConfiguration) => {
                            loggerConfiguration
                                .ReadFrom.Configuration(hostingContext.Configuration)
                                .Enrich.FromLogContext()
                                // Just to show the app name
                                .Enrich.WithProperty("ApplicationName", typeof(Program).Assembly.GetName().Name)
                                // To show environment running in
                                .Enrich.WithProperty("Environment", hostingContext.HostingEnvironment)
                                .WriteTo.Console(theme: AnsiConsoleTheme.Literate);
#if DEBUG
                            // Used to filter out potentially bad data due debugging.
                            // Very useful when doing Seq dashboards and want to remove logs under debugging session.
                            loggerConfiguration.Enrich.WithProperty("DebuggerAttached", Debugger.IsAttached);
#endif
                        });
                });
    }
}
