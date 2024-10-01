using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoomApp.Models
{
    public class MeetingInfo
    {
        public string MeetingNumber { get; set; }
        public string MeetingTopic { get; set; }
        public DateTime StartTime { get; set; }
        public int DurationMinutes { get; set; }
        public string HostName { get; set; }
        public string Password { get; set; }
        public bool IsRecurring { get; set; }

        public override string ToString()
        {
            return $"{MeetingTopic} ({MeetingNumber}) - {StartTime:g}";
        }
    }
}
