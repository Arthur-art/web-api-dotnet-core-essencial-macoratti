using System.ComponentModel.DataAnnotations;

namespace web_api_catalog.Domain;

public class Logs
{
    public Logs(string messageLog, string dateTime)
    {
        MessageLog = messageLog;
        DateTime = dateTime;
    }

    [Key]
    public int logId { get; set; }
    public string MessageLog { get; set; }
    public string DateTime { get; set; }
}
