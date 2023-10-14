namespace Zadanie1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }


        private async void StartBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WidokGry());
        }

        private async void IntrukcjaBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WidokInstrukcji());
        }
    }
}