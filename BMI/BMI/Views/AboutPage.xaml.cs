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
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            FormattedString formattedString = new FormattedString();
            formattedString.Spans.Add(new Span { Text = Xamarin.Essentials.AppInfo.Name, FontSize = 22, FontAttributes = FontAttributes.Bold });
            //var span = new Span { Text = "default, " };
            //span.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(async () => await DisplayAlert("Tapped", "This is a tapped Span.", "OK")) });
            //formattedString.Spans.Add(span);
            formattedString.Spans.Add(new Span { Text = " " + Xamarin.Essentials.AppInfo.Version.ToString() });
            AppInformation.FormattedText = formattedString;
        }
    }
}