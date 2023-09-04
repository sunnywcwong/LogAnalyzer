using LogAnalyzer.Interfaces;
using Microsoft.Extensions.Logging;

namespace LogAnalyzer.Services;

public class LogAnalyzerService : ILogAnalyzerService
{
    private readonly ILogger<LogAnalyzerService> _logger;

    public LogAnalyzerService(ILogger<LogAnalyzerService> logger)
    {
        _logger = logger;
    }

    public int GetUniqueIpCount(IList<string> ips)
    {
        var uniqueIps = new List<string>();

        foreach (var ip in ips)
        {
            if (!uniqueIps.Contains(ip))
                uniqueIps.Add(ip);
            else
                _logger.LogDebug($"Duplicate IP {ip} found.");
        }

        return uniqueIps.Count;
    }

    public IList<string> GetTopMost(IList<string> items, int top)
    {
        var counter = new Dictionary<string, int>();

        foreach (var item in items)
        {
            if (counter.TryGetValue(item, out int count))
                counter[item] = ++count;
            else
                counter.Add(item, 1);
        }

        return counter.OrderByDescending(c => c.Value)
            .Select(c => c.Key)
            .Take(top)
            .ToList();
    }
}
