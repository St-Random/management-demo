using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;

namespace iTechArt.ManagementDemo.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // NLog: setup the logger first to catch all errors
            var logger = NLogBuilder
                .ConfigureNLog("NLog.config")
                .GetCurrentClassLogger();
            try
            {
                logger.Debug("Starting.");
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                //NLog: catch setup errors
                logger.Error(ex, "Aborted because of exception");
                throw;
            }
            finally
            {
                /* Ensure to flush and stop internal timers/threads 
                 * before application-exit (Avoid segmentation fault on Linux) */
                LogManager.Shutdown();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging(
                    logging =>
                    {
                        logging.ClearProviders();
                        logging.SetMinimumLevel(
                            Microsoft.Extensions.Logging.LogLevel.Trace);
                    })
                .UseNLog();
    }
}
