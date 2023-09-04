using MiniLogParser.Interfaces;
using MiniLogParser.Models;

namespace MiniLogParser.Services;

public class LogReader : ILogReader
{
    public readonly IMiniLogService _miniLogService;

    public LogReader(IMiniLogService miniLogService)
    {
        _miniLogService = miniLogService;
    }

    public IList<MiniLog> ReadLog(string filePath)
    {
        return _miniLogService.GetMiniLogs(filePath);
    }
}
