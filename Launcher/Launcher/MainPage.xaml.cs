using System;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;
using Launcher.Pages;
using Launcher.Pages.Greeting;
using Launcher.Pages.QECalculator;

namespace Launcher
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void GreetingBtnClicked(object sender, EventArgs e)
        {
            var greetingPage = new GreetingPage();
            await Application.Current.MainPage.Navigation.PushAsync(greetingPage);
        }

        private async void GoogleBtnClicked(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync("https://www.google.com", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private async void MapBtnClicked(object sender, EventArgs e)
        {
            var location = new Location(47.645160, -122.1306032);
            try
            {
                await Map.OpenAsync(location);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            /*
             var mapUri = new UriBuilder("geo:37.422219,-122.08364?z=14").Uri;
             await Launcher.TryOpenAsync(mapUri);
            */

        }

        private void PhoneBtnClicked(object sender, EventArgs e)
        {
            try
            {
                PhoneDialer.Open("123456789");
            }
            catch (ArgumentNullException anEx)
            {
                // Number was null or white space
                Debug.WriteLine(anEx.Message);
            }
            catch (FeatureNotSupportedException ex)
            {
                // Phone Dialer is not supported on this device.
                Debug.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                // Other error has occurred.
                Debug.WriteLine(ex.Message);
            }
        }

        private async void QECalculatorBtnClicked(object sender, EventArgs e)
        {
            var calculatorPage = new QECalculatorPage();
            var calculatorViewModel = new QECalculatorViewModel();
            calculatorPage.BindingContext = calculatorViewModel;
            await Application.Current.MainPage.Navigation.PushAsync(calculatorPage);
        }
    }
}
