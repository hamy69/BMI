using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BMI.Views;
using System.Windows.Input;

namespace BMI
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AppShell : Shell
    {
        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes { get { return routes; } }

        public ICommand SettingPageCommand => new Command(async () => await NavigateToSettingAsync());

        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;
        }

        void RegisterRoutes()
        {
            routes.Add("Loging", typeof(LogingPage));
            routes.Add("SignUp", typeof(SignUpPage));
            routes.Add("About", typeof(AboutPage));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }

        async Task NavigateToSettingAsync()
        {
            Shell.Current.FlyoutIsPresented = false;
            await Navigation.PushAsync(new SettingsPage());
        }

        private void OnNavigating(object sender, ShellNavigatingEventArgs e)
        {
            // Cancel any back navigation
            //if (e.Source == ShellNavigationSource.Pop)
            //{
            //    e.Cancel();
            //}
        }
        
        private void OnNavigated(object sender, ShellNavigatedEventArgs e)
        {

        }
    }
}
