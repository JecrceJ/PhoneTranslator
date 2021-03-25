using System;
using Xamarin.Forms;

namespace Phoneword
{
    public partial class MainPage : ContentPage
    {
        string translatedNumber;
        public MainPage()
        {
            InitializeComponent();
        }
        void OnTranslate(object sender, EventArgs e)
        {
            translatedNumber = Core.PhonewordTranslator.ToNumber(x.phoneNumberText.Text);
            if (!string.IsNullOrWhiteSpace(translatedNumber))
            {
                callButon.IsEnabled = true;
                callButon.Text = "Call " + translatedNumber;
            }
            else
            {
                callButon.Enabled = false;
                callButon.Text = "Call";
            }
        }
        async void onCall(object sender, EventArgs e)
        {
            if (await this.DisplayAlert(
                    "Dial a number",
                    "Would you like to call " + translatedNumber + "?",
                    "Yes",
                    "No"))
            {
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                    dialer.Dial(translatedNumber);
            }
        }
    }
}