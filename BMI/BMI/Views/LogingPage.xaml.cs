using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BMI;
using BMI.Views;

namespace BMI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogingPage : ContentPage
    {
        public LogingPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this.BMILoging, true);
            var forgetpassword_tap = new TapGestureRecognizer();
            forgetpassword_tap.Tapped += Forgetpassword_tap_Tapped;
            forgetLabel.GestureRecognizers.Add(forgetpassword_tap);
        }

        private void Forgetpassword_tap_Tapped(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Loging_Button_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new AppShell();
        }

        private async void signUp_ClickedEvent(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}