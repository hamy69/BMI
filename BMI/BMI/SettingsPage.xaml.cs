using System;
using System.Resources;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BMI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            AppInfo.Detail = "Veresion : " + Xamarin.Essentials.AppInfo.Version.ToString();
        }

        private void WipeUserData_Tapped(object sender, EventArgs e)
        {

        }

        private void PhoneSeting_Tapped(object sender, EventArgs e)
        {
            Xamarin.Essentials.AppInfo.ShowSettingsUI();
            //Xamarin.Essentials.ApplicationSettings.Open();
            //AppInfo.OpenSettings();
        }

        private async void AppInfo_Tapped(object sender, EventArgs e)
        {
            //string ar = Resources.GetString(Resource.String.Author);
            string MessageStr = string.Format("{0}, Veresion : {1}.\n.",
                Xamarin.Essentials.AppInfo.Name,
                Xamarin.Essentials.AppInfo.Version);
            await DisplayAlert(Xamarin.Essentials.AppInfo.Name, MessageStr, "OK");
        }

        private async void ChangePassword_Tapped(object sender, EventArgs e)
        {
            string pass = await DisplayPromptAsync("Courent Password", "Enter your courent password?", "Enter", "Cancel", "Password", -1, null, "");
            
        }
    }
}