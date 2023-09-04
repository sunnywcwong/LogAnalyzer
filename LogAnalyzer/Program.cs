using AutoMapper;
using LogAnalyzer.Enums;
using LogAnalyzer.Interfaces;
using LogAnalyzer.Models;
using LogAnalyzer.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MiniLogParser.Interfaces;
using MiniLogParser.Models;
using MiniLogParser.Services;

namespace Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 2) 
                throw new ArgumentException("Usage: LogAnalyzer.exe filePath UniqueIpCount|Top3Url|Top3Ip");

            // TODO: Need arguments validation here
            var filePath = args[0];
            var _ = Enum.TryParse(args[1], out TaskEnum mode);

            // Dependency Injections
            var serviceProvider = ConfigureServiceProvider();
            var logReader = serviceProvider.GetService<ILogReader>();
            var logAnalyzerService = serviceProvider.GetService<ILogAnalyzerService>();

            // Configure Automapper
            var mapper = InitializeAutomapper();

            // Retrieve logs
            var miniLogs = logReader.ReadLog(filePath);
            var logs = mapper.Map<IList<Log>>(miniLogs);

            switch (mode)
            {
                case TaskEnum.UniqueIpCount:
                    var count = logAnalyzerService.GetUniqueIpCount(logs.Select(l => l.IP).ToList());
                    Console.WriteLine($"UniqueIpCount = {count}");
                    break;

                case TaskEnum.Top3Url:
                    var urls = logAnalyzerService.GetTopMost(logs.Select(l => l.Url).ToList(), 3);
                    Console.WriteLine($"Top 3 Urls:");
                    
                    foreach(var url in urls) 
                        Console.WriteLine(url);

                    break;

                case TaskEnum.Top3Ip:
                    var ips = logAnalyzerService.GetTopMost(logs.Select(l => l.IP).ToList(), 3);
                    Console.WriteLine($"Top 3 IPs:");

                    foreach (var ip in ips)
                        Console.WriteLine(ip);

                    break;
            }
        }

        private static ServiceProvider ConfigureServiceProvider()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder =>
                {
                    builder.AddConsole();
                    builder.SetMinimumLevel(LogLevel.Debug);
                })
                .AddScoped<ILogReader, LogReader>()
                .AddScoped<IMiniLogService, MiniLogService>()
                .AddScoped<ILogAnalyzerService, LogAnalyzerService>()
                .BuildServiceProvider();

            return serviceProvider;
        }

        private static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MiniLog, Log>();
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}