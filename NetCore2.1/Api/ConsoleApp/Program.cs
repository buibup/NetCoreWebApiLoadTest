﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        public static List<Task> TaskList = new List<Task>();

        static void Main(string[] args)
        {

            TaskList.Add(RunningAsync());
            TaskList.Add(RunningAsync());
            TaskList.Add(RunningAsync());
            TaskList.Add(RunningAsync());
            TaskList.Add(RunningAsync());

            Task.WaitAll(TaskList.ToArray());
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }

        static async Task RunningAsync()
        {
            RegisterServices();
            var service = _serviceProvider.GetService<IRunningOrderRefNoRepository>();
            const int n = 100_000;
            for (int i = 1; i < n; i++)
            {
                //Thread.Sleep(100);
                var data = await service.GetRunningOrderRefNo();

                Console.WriteLine($"{i} : {data}");
            }

            Console.ReadLine();
            DisposeServices();
        }


        private static void RegisterServices()
        {
            var connectionString = @"Server=192.168.35.50,9677;Database=NK_KOLDTA;User ID=mbadmin; PWD=MB@dmin2012;";
            var collection = new ServiceCollection();
            collection.AddScoped<IRunningOrderRefNoRepository>(_ => new RunningOrderRefNoRepository(connectionString));
            //collection.AddScoped<IRunningOrderRefNoRepository, RunningOrderRefNoRepository>();
            // ...
            // Add other services
            // ...
            _serviceProvider = collection.BuildServiceProvider();
        }
        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
