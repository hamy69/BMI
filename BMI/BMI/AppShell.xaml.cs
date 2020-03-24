using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BMI.Views;
using System.Windows.Input;
using BMI.Models;
using System.IO;

namespace BMI
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AppShell : Shell
    {
        readonly Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes { get { return routes; } }

        //public ICommand SettingPageCommand => new Command(async () => await NavigateToSettingAsync());
        //public ICommand LogoutCommand => new Command(LogoutToLogingPage);

        //readonly Users user = new Users();
        //private readonly UserDataStorage userDB = new UserDataStorage();
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            
            //user = App.User;
            BindingContext = (Users)App.User;
            //BindingContext = this;
        }

        void RegisterRoutes()
        {
            routes.Add("BMI", typeof(BMIPage));
            routes.Add("Histogram", typeof(HistogramofBMIPage));
            routes.Add("Calorie", typeof(caloriePage));
            routes.Add("About", typeof(AboutPage));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }

        /*async Task NavigateToSettingAsync()
        {
            Shell.Current.FlyoutIsPresented = false;
            await Navigation.PushAsync(new SettingsPage());
        }

        void LogoutToLogingPage()
        {
            Shell.Current.FlyoutIsPresented = false;
            Application.Current.MainPage = new NavigationPage(new LogingPage());
            //await Navigation.PushAsync(new LogingPage());
        }*/

        private void OnNavigating(object sender, ShellNavigatingEventArgs e)
        {
            // Cancel any back navigation
            if (e.Source == ShellNavigationSource.Pop)
            {
                //e.Cancel();
            }
        }
        
        private void OnNavigated(object sender, ShellNavigatedEventArgs e)
        {

        }

        private async void MenuItem_SettingPage_Clicked(object sender, EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = false;
            //await Shell.Current.Navigation.PushAsync(new SettingsPage());
            await Navigation.PushAsync(new SettingsPage());
        }
        private void MenuItem_Logout_Clicked(object sender, EventArgs e)
        {
            // Hide Flyout menu
            Shell.Current.FlyoutIsPresented = false;
            // Distroy loging Cache 
            File.Delete(App.CachePath);
            // Navigate to loging Page
            Application.Current.MainPage = new NavigationPage(new LogingPage());
        }
    }
}
