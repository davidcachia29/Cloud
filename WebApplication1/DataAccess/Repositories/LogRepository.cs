using Google.Api;
using Google.Cloud.Logging.Type;
using Google.Cloud.Logging.V2;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DataAccess.Interfaces;

namespace WebApplication1.DataAccess.Repositories
{
    public class LogRepository : ILogRepository
    {
        private string projectId;
        public LogRepository(IConfiguration config)
        {
            projectId = config.GetSection("AppSettings").GetSection("ProjectId").Value;
        }

        public void Log(string message, LogSeverity severity)
        {
            var client = LoggingServiceV2Client.Create();
            LogName logName = new LogName(projectId, "pfc2021msd63a");
            LogEntry logEntry = new LogEntry
            {
                LogName = logName.ToString(),
                Severity = severity,
                TextPayload = $"{message}"
            };

            MonitoredResource resource = new MonitoredResource { Type = "global" };
            //IDictionary<string, string> entryLabels = new Dictionary<string, string>
            //{
            //    { "size", "large" },
            //    { "color", "red" }
            //};

            client.WriteLogEntries(logName,resource,null,new List<LogEntry>() { logEntry });
           
        }
    }
}
