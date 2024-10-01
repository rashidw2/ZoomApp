using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoomApp.Models;

namespace ZoomApp.Interfaces
{
    public interface IZoomService
    {
        bool InitializeSdk();
        bool JoinMeeting(string meetingNumber, string password);
        bool StartMeeting(string meetingNumber);
        IntPtr GetMeetingView();
        List<MeetingInfo> GetScheduledMeetings();
    }
}
