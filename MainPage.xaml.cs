using System;
using Xamarin.Forms;

namespace Phoneword
{
    public partial class MainPage : ContentPage
    {
        string translated Number;
        public MainPage ()
        {
            InitializeComponent ();
        }
        void OnTranslate (object sender, EventArgs e)
        {
            translatedNumber=Core.PhonewordTranslator.ToNumber (phoneNumberText.Text);
            if (!string.IsNullOrWhiteSpace (translatedNumber)) {
                callButton.IsEnabled = true;
                callButton.Text = "Call " + translatedNumber;
            } else {
                callButton.IsEnabled = false;
                callButton.Text = "Call";
            }
        }
        async void onCall (object sender, EventArgs e)
        {
            if (await this.DisplayAlert (
                    "Dial a number",
                    "Would you like to call " + translatedNumber + "?",
                    "Yes",
                    "No")) {
                var dialer = DependencyService.Get<IDialer> ();
                if (dialer != null)
                    dialer.Dial (translatedNumber);
            }
        }
    }
}