using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BMI;
using BMI.Views;
using BMI.Data;

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
            UserDataStorage userD = new UserDataStorage();
            if (!userD.ExistDB) userD.UserDB();
            if (userD.LoginValidate(EmailIDEntry.Text, PasswordEntry.Text))
            {
                Application.Current.MainPage = new AppShell(userD.GetSpecificUser(EmailIDEntry.Text).ID);
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