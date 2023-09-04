using System.Diagnostics.CodeAnalysis;

namespace LogAnalyzer.Models;

[ExcludeFromCodeCoverage]
public class Log
{
    public Log(string ip, string url)
    {
        IP = ip;
        Url = url;
    }

    public string IP { get; init; }
    public string Url { get; init; }
}
