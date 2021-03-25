using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using ShirtStoreWebsite.Data;
using Microsoft.Extensions.Hosting;

namespace ShirtStoreWebsite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureLogging((hostingContext, logging) =>
            {
                var env = hostingContext.HostingEnvironment;
                var config = hostingContext.Configuration.GetSection("Logging");

                logging.ClearProviders();

                if (env.IsDevelopment())
                {
                    logging.AddConfiguration(config);
                    logging.AddConsole();
                }
                else
                {
                    logging.AddFile(config);
                }

            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}

