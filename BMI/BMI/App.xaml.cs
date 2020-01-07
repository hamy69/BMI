using BMI.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BMI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            MainPage = new NavigationPage(new LogingPage());
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
