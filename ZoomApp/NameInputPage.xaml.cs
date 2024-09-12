namespace ZoomApp
{
    public partial class NameInputPage : ContentPage
    {
        public NameInputPage()
        {
            InitializeComponent();
        }

        private async void OnContinueClicked(object sender, EventArgs e)
        {
            string userName = UserNameEntry.Text;

            if (!string.IsNullOrWhiteSpace(userName))
            {
                // You can save or use the user name as needed here

                // Navigate to the meeting page
                await Navigation.PushAsync(new MeetingPage(userName));
            }
            else
            {
                await DisplayAlert("Error", "Please enter your name.", "OK");
            }
        }
    }
}
