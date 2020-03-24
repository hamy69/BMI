using BMI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        // Dictionary to get Gender.  1.Male 2.Female 3.Other
        Dictionary<string, int> Gender = new Dictionary<string, int>
        {
            { "Male", 1 }, { "Female", 2 }, {"Other", 3}
        };
        public SignUpPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            foreach (string GenderName in Gender.Keys)
            {
                GenderPicker.Items.Add(GenderName);
            }
        }

        private async void signUp_Clicked(object sender, EventArgs e)
        {
            //SignupValidation_ButtonClicked
            //UserDataStorageDirect userDB = new UserDataStorageDirect(App.DBPath);
            //userDB.UserDB();
            Users NewUser = new Users();



            if ((string.IsNullOrWhiteSpace(emailEntry.Text)) || (string.IsNullOrWhiteSpace(fullNameEntry.Text))||
                (string.IsNullOrWhiteSpace(passwordEntry.Text)) || (string.IsNullOrWhiteSpace(lengthEntry.Text)) ||
                (string.IsNullOrEmpty(emailEntry.Text)) || (string.IsNullOrEmpty(fullNameEntry.Text)) ||
                (string.IsNullOrEmpty(passwordEntry.Text)) || (string.IsNullOrEmpty(lengthEntry.Text)))
            {
                await DisplayAlert("Enter Data", "Enter Valid Data", "OK");
            }
            else if (!string.Equals(passwordEntry.Text, confirmpasswordEntry.Text))
            {
                warningLabel.Text = "Enter Same Password!";
                passwordEntry.Text = string.Empty;
                confirmpasswordEntry.Text = string.Empty;
                warningLabel.TextColor = Color.IndianRed;
                warningLabel.IsVisible = true;
            }
            else if (lengthEntry.Text.Length < 3)
            {
                lengthEntry.Text = string.Empty;
                lengthWarLabel.Text = "Enter true length Number!";
                lengthWarLabel.TextColor = Color.IndianRed;
                lengthWarLabel.IsVisible = true;
            }
            else if ((DateTime.Now.Year-birthdatePicker.Date.Year) <= 0 && (DateTime.Now.Year - birthdatePicker.Date.Year) > 100)
            {
                birthdatePicker.Date = new DateTime();
                AgeWarLabel.Text = "Choose true date!";
                AgeWarLabel.TextColor = Color.IndianRed;
                AgeWarLabel.IsVisible = true;
            }
            else if (GenderPicker.SelectedIndex == -1)
            {
                GenderWarLabel.Text = "please Choose a Gender!";
                GenderWarLabel.TextColor = Color.IndianRed;
                GenderWarLabel.IsVisible = true;
            }
            else
            {
                NewUser.UserName = emailEntry.Text;
                NewUser.FullName = fullNameEntry.Text;
                NewUser.Gender = Gender[GenderPicker.Items[GenderPicker.SelectedIndex]];
                NewUser.password = passwordEntry.Text;
                NewUser.length = Convert.ToInt32(lengthEntry.Text);
                NewUser.birthdate = birthdatePicker.Date;
                try
                {
                    var retrunvalue = App.Database.SaveUser(NewUser);
                    if (retrunvalue == "Sucessfully Added")
                    {
                        await DisplayAlert("User Add", retrunvalue, "OK");

                        await Navigation.PushAsync(new LogingPage(emailEntry.Text, passwordEntry.Text));
                    }
                    else
                    {
                        await DisplayAlert("User Add", retrunvalue, "OK");
                        warningLabel.IsVisible = false;
                        emailEntry.Text = string.Empty;
                        fullNameEntry.Text = string.Empty;
                        passwordEntry.Text = string.Empty;
                        confirmpasswordEntry.Text = string.Empty;
                        lengthEntry.Text = string.Empty;
                        birthdatePicker.Date = new DateTime();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        private async void login_ClickedEvent(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new LogingPage());
            await Navigation.PopAsync(true);
        }
    }
}