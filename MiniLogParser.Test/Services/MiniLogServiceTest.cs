using MiniLogParser.Models;
using MiniLogParser.Services;

namespace MiniLogParser.Test.Services;

public class MiniLogServiceTest
{
    private readonly MiniLogService _miniLogService;

    public MiniLogServiceTest()
    {
        _miniLogService = new MiniLogService();
    }

    [Theory]
    [InlineData("177.71.128.21", "GET /intranet-analytics/ HTTP/1.1", "177.71.128.21 - - [10/Jul/2018:22:21:28 +0200] \"GET /intranet-analytics/ HTTP/1.1\" 200 3574 \"-\" \"Mozilla/5.0 (X11; U; Linux x86_64; fr-FR) AppleWebKit/534.7 (KHTML, like Gecko) Epiphany/2.30.6 Safari/534.7\"")]
    [InlineData("50.112.00.11", "GET /hosting/ HTTP/1.1", "50.112.00.11 - admin [11/Jul/2018:17:31:05 +0200] \"GET /hosting/ HTTP/1.1\" 200 3574 \"-\" \"Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/536.6 (KHTML, like Gecko) Chrome/20.0.1092.0 Safari/536.6\"")]
    public void GetMiniLogs_Should_ReturnExpected(string expectedIp, string expectedUrl, string logString)
    {
        // arrange
        var logs = new List<string>
        {
            logString
        };

        var expected = new List<MiniLog>{
            new MiniLog(expectedIp, expectedUrl) 
        };

        // act
        var actual = _miniLogService.GetMiniLogs(logs);

        // assert
        actual.Should().BeEquivalentTo(expected);

    }
}