using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BMI;
using BMI.Views;
using System.IO;

namespace BMI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogingPage : ContentPage
    {
        private int WrongCount = 0;
        public LogingPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this.BMILoging, true);
            var forgetpassword_tap = new TapGestureRecognizer();
            forgetpassword_tap.Tapped += Forgetpassword_tap_Tapped;
            forgetLabel.GestureRecognizers.Add(forgetpassword_tap);
        }
        public LogingPage(string user, string pass)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this.BMILoging, true);
            var forgetpassword_tap = new TapGestureRecognizer();
            forgetpassword_tap.Tapped += Forgetpassword_tap_Tapped;
            forgetLabel.GestureRecognizers.Add(forgetpassword_tap);
            EmailIDEntry.Text = user;
            PasswordEntry.Text = pass;
        }

        private void Forgetpassword_tap_Tapped(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Loging_Button_Clicked(object sender, EventArgs e)
        {
            //UserDataStorageDirect userD = new UserDataStorageDirect(App.DBPath);
            //if (!userD.ExistDB) userD.UserDB();
            if (App.Database.LoginValidateAsync(EmailIDEntry.Text, PasswordEntry.Text))
            {
                // set static app  parameters 
                App.UserID = App.Database.GetUser(EmailIDEntry.Text).ID;
                // set cache file for another time login
                string _CacheTime = DateTime.UtcNow.ToString();
                string _CacheID = App.UserID.ToString();
                string _Cache = $"{_CacheTime}\n{_CacheID}";
                File.WriteAllText(App.CachePath, _Cache);
                // log to personal page
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                // show Error message
                warningLabel.Text = string.Format("Enter {0} times wrong email or password.", ++WrongCount);
                warningLabel.IsVisible = true;
            }
        }

        private async void SignUp_ClickedEvent(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}