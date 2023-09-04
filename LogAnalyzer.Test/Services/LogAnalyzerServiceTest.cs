using LogAnalyzer.Services;
using Microsoft.Extensions.Logging;

namespace LogAnalyzer.Test.Services;

public class LogAnalyzerServiceTest
{
    private readonly LogAnalyzerService _logAnalyzerService;

    public LogAnalyzerServiceTest()
    {
        var logger = Substitute.For<ILogger<LogAnalyzerService>>();

        _logAnalyzerService = new LogAnalyzerService(logger);
    }


    [Fact]
    public void GetUniqueIpCount_When_ThereAreDuplicates_Should_Return_Expected()
    {
        // arrange
        var ips = new List<string>
        {
            "168.41.191.40",
            "168.41.191.41",
            "168.41.191.40"
        };

        var expected = 2;

        // act
        var actual = _logAnalyzerService.GetUniqueIpCount(ips);

        // assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetUniqueIpCount_When_NoDuplicates_Should_Return_Expected()
    {
        // arrange
        var ips = new List<string>
        {
            "168.41.191.40",
            "168.41.191.41",
            "168.41.191.42"
        };

        var expected = 3;

        // act
        var actual = _logAnalyzerService.GetUniqueIpCount(ips);

        // assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetTopMost_Should_Return_Expected()
    {
        //arrange
        var items = new List<string>
        {
            "177.71.128.21",
            "168.41.191.40",
            "168.41.191.41",
            "168.41.191.41",
            "168.41.191.41",
            "168.41.191.40",
            "177.71.128.21",
            "168.41.191.40",
            "168.41.191.40",
            "168.41.191.40",
            "168.41.191.40",

            "168.41.191.43",
            "168.41.191.40",
            "168.41.191.34",
        };

        var expected = new List<string>
        {
            "177.71.128.21",
            "168.41.191.40",
            "168.41.191.41"
        };

        // act
        var actual = _logAnalyzerService.GetTopMost(items, 3);

        // assert 
        actual.Should().BeEquivalentTo(expected);
    }
}