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
    public partial class BMIEntryPage : ContentPage
    {
        public delegate void SetWeightEventHandler(object source, EventArgs args);
        public event SetWeightEventHandler WeightSet;

        public BMIEntryPage()
        {
            InitializeComponent();
        }
        protected virtual void OnWeightSet()
        {
            if (WeightSet != null)
            {
                WeightSet(this, EventArgs.Empty);
            }
        }
        private async void Submit_ClickedAsync(object sender, EventArgs e)
        {
            if(WeightEntry.Text != null)
            {
                BMIPage.Weight = Convert.ToDouble(WeightEntry.Text);
                OnWeightSet();
                await Navigation.PopModalAsync();
            }
            else
            {
                // allert to user
                await DisplayAlert("Enter Data", "Enter Valid Data", "OK");
            }
        }
    }
}