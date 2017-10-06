using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration config=new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("hosting.json",optional:true)
            .Build();

            BuildWebHost(args,config).Run();
        }

        public static IWebHost BuildWebHost(string[] args,IConfiguration config) =>
            WebHost.CreateDefaultBuilder(args)
            .UseConfiguration(config)
            .UseKestrel()
            .UseIISIntegration()
            .UseStartup<Startup>()
            //.UseUrls("http://*:8080")
            .Build();
    }
}
