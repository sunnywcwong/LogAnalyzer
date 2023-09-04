using MiniLogParser.Interfaces;
using MiniLogParser.Models;
using System.Diagnostics.CodeAnalysis;

namespace MiniLogParser.Services;

public class MiniLogService : IMiniLogService
{
    [ExcludeFromCodeCoverage]
    public IList<MiniLog> GetMiniLogs(string path)
    {
        var lines = File.ReadLines(path).ToList();

        return GetMiniLogs(lines);
    }

    public IList<MiniLog> GetMiniLogs(IList<string> lines)
    {
        var miniLogs = new List<MiniLog>();

        foreach (var line in lines)
        {
            var ip = line.Split(' ')[0];
            var url = line.Split('\"')[1]; // we can split again if not interested in http protocol and verb

            miniLogs.Add(new MiniLog(ip, url));
        }

        return miniLogs;
    }
}