using MiniLogParser.Models;

namespace MiniLogParser.Interfaces;

public interface ILogReader
{
    IList<MiniLog> ReadLog(string filepath);
}
