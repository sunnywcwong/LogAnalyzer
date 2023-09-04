using LogAnalyzer.Models;
namespace LogAnalyzer.Interfaces;

public interface ILogAnalyzerService
{
    int GetUniqueIpCount(IList<string> ips);
    IList<string> GetTopMost(IList<string> urls, int top);
}
