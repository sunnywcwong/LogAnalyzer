using System.Diagnostics.CodeAnalysis;

namespace MiniLogParser.Models;

[ExcludeFromCodeCoverage]
public class MiniLog
{
    public MiniLog(string ip, string url)
    {
        IP = ip;
        Url = url;
    }

    public string IP { get; init; }
    public string Url { get; init; }
}
