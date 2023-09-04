using MiniLogParser.Models;

namespace MiniLogParser.Interfaces
{
    public interface IMiniLogService
    {
        IList<MiniLog> GetMiniLogs(string path);
    }
}