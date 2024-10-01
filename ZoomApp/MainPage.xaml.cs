using System;
using System.Collections.ObjectModel;
using ZoomApp.Interfaces;
using ZoomApp.Models;

namespace ZoomApp;

public partial class MainPage : ContentPage
{
    private readonly IZoomService _zoomService;
    public ObservableCollection<MeetingInfo> Meetings { get; set; }
    public IntPtr MeetingHandle { get; private set; }

    public MainPage(IZoomService zoomService)
    {
        InitializeComponent();
        _zoomService = zoomService;
        Meetings = new ObservableCollection<MeetingInfo>();
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await Task.Run(() => LoadMeetings());
    }

    private async void LoadMeetings()
    {
        try
        {
            var scheduledMeetings = _zoomService.GetScheduledMeetings();
            Meetings.Clear();
            foreach (var meeting in scheduledMeetings)
            {
                Meetings.Add(meeting);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to load meetings: {ex.Message}", "OK");
        }
    }

    private async void OnJoinMeetingClicked(object sender, EventArgs e)
    {
        var selectedMeeting = (MeetingInfo)MeetingsListView.SelectedItem;
        if (selectedMeeting == null)
        {
            await DisplayAlert("Error", "Please select a meeting to join.", "OK");
            return;
        }

        if (_zoomService.InitializeSdk())
        {
            bool joined = _zoomService.JoinMeeting(selectedMeeting.MeetingNumber, selectedMeeting.Password);
            if (joined)
            {
                MeetingHandle = _zoomService.GetMeetingView();
                MeetingView.IsVisible = true;
                await DisplayAlert("Success", "Joined the meeting successfully.", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Failed to join the meeting.", "OK");
            }
        }
        else
        {
            await DisplayAlert("Error", "Failed to initialize Zoom SDK.", "OK");
        }
    }
}