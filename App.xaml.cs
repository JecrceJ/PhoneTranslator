using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Phoneword
{
    public partial class App : Application
    {
        public App()
        {
            initializeComponent();
            MainPage = new Mainpage();
        }

        protected override void OnStart()
        {
            //Handle when your app starts
        }
        
        protected override void OnSleep()
        {
            //Hanfle when your app sleeps
        }
        
        protected override void OnResume()
        {
            //Handle when your app resumes
        }
    }
}