namespace ZoomApp
{
    public partial class MeetingPage : ContentPage
    {
        public MeetingPage(string userName)
        {
            InitializeComponent();
            MenuPicker.SelectedIndex = 0;
            WelcomeLabel.Text = $"Hello, {userName}! Welcome to the meeting.";
        }
        private async void OnMenuClicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Menu", "Cancel", null, "Option 1", "Option 2");
            if (action == "Option 1")
            {
                // Handle Option 1
            }
            else if (action == "Option 2")
            {
                // Handle Option 2
            }
        }
    }
    

}