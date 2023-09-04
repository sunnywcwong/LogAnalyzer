# Log Analyzer

## What does it do?
For a given log file we want to know,
- The number of unique IP addresses
- The top 3 most visited URLs
- The top 3 most active IP addresses

## Structure
- Log Analyzer - Pass a log file to a parser and analyze Ilog
- MiniLogParser - Takes a given file path and parse the multiple strings of log into IMiniLog

## Assumptions and Limitations
### MiniLogParser
It assumes the log file is small and reads all strings in the memory. It should not be used to handle file size > 50MB. 

It use .Net split() to parse the log. For it to work for other properties, it is better to rewrite that part by using Regex.

## Usage/Examples
```
LogAnalyzer.exe filepath UniqueIpCount|Top3Url|Top3Ip
```

OR

When running from Visual Studio, change the commandLineArgs in LogAnalyzer\Properties\launchSettings.json
```
{
  "profiles": {
    "LogAnalyzer": {
      "commandName": "Project",
      "commandLineArgs": "filepath" "UniqueIpCount|Top3Url|Top3Ip"
    }
  }
}
```
### The number of unique IP addresses

```dotnet
LogAnalyzer.exe xyz.log UniqueIpCount
```

Output
```
UniqueIpCount = 11
```
### The top 3 most visited URLs 

```dotnet
LogAnalyzer.exe xyz.log UniqueIpCount
```

Output
```
Top 3 Urls:
GET /docs/manage-websites/ HTTP/1.1
GET /intranet-analytics/ HTTP/1.1
GET http://example.net/faq/ HTTP/1.1
```
### The top 3 most active IP addresses

```dotnet
LogAnalyzer.exe xyz.log UniqueIpCount
```

Output
```
Top 3 IPs:
168.41.191.40
177.71.128.21
50.112.00.11
```