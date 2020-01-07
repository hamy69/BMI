using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BMI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }

        private void signUp_Clicked(object sender, EventArgs e)
        {
            //SignupValidation_ButtonClicked

        }

        private async void login_ClickedEvent(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogingPage());
        }
    }
}