using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Reflection;

namespace ConsoleApp
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            Console.WriteLine("Hello World!");

            log.Info("İnfo");
            log.Error("Error");
            log.Warn("Warn");
            log.Fatal("Fatal");
            log.Debug("Debug");
        }
    }
}
