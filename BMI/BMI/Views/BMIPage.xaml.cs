using BMI.Models;
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
    public partial class BMIPage : ContentPage
    {
        static Double _Weight;
        public static Double Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }
        private List<BMIs> _BMIs;
        private BMIs _BMI;
        //private int User_age=0;
        //private Double length=0;
        //private Double mass =0;
        //public float BMI;
        //public float BMR;
        //public static readonly BindableProperty UserProperty = BindableProperty.Create<Users, user>(p => p.user, new Users());
        //public Users user
        //{
        //    get => (Users)GetValue(UserProperty);
        //    set => SetValue(UserProperty, value);
        //}

        //Users user;
        //public int age
        //{
        //    //get { return (int)GetValue(length); }
        //}
        public BMIPage()
        {
            InitializeComponent();
            _BMIs = App.Database.GetBMI(App.UserID);
            if (_BMIs.Count > 0)
            {
                _BMI = _BMIs[_BMIs.Count - 1];
                ShowBMIResult();
            }
            else
            {
                ShowBMINoResult();
            }
        }
        public void OnWeightSet(object source, EventArgs e)
        {
            Generator();
        }

        private void Generator()
        {
            if (_Weight != 0)
            {
                int User_age = DateTime.Now.Year - ((Users)BindingContext).birthdate.Year;
                Double length = ((Users)BindingContext).length;
                //Double mass = Convert.ToDouble(WeightEntry.Text);
                
                BMIs BMI = new BMIs();
                BMI.time = DateTime.UtcNow;
                BMI.UserID = ((Users)BindingContext).ID;
                BMI.BMI = _Weight / ((length / 100) * (length / 100));
                BMI.weight = _Weight;
                if (((Users)BindingContext).Gender == 1) // Gender  = 1 means User Gender is Man
                    BMI.BMR = (_Weight * 13.7) - (length * 5) + (User_age * 8.6) + 66;
                else
                    BMI.BMR = (_Weight * 9.7) - (length * 1.7) + (User_age * 4.7) + 655;
                //Res.Text += ("  BMR =" + BMR);
                App.Database.AddBMI(BMI);
                _BMI = BMI;

                ShowBMIResult();
            }
            
        }

        private void ShowBMIResult()
        {
            ResBMI.Text = string.Empty;
            ResBMI.FontSize = 17;
            ResBMI.TextColor = Color.Black;
            if (_BMI.BMI < 19)
            {
                ResBMI.Text = $"you have low mass. BMI = {_BMI.BMI:F2}";
                ResBMI.TextColor = Color.FromHex("#2196F3");
            }
            else if (_BMI.BMI <= 24)
            {
                ResBMI.Text = $"you have normall mass. BMI = {_BMI.BMI:F2}";
                ResBMI.TextColor = Color.FromHex("#90EE02");
            }
            else if (_BMI.BMI <= 29)
            {
                ResBMI.Text = $"you are low fat(degre1). BMI = {_BMI.BMI:F2}";
                ResBMI.TextColor = Color.FromHex("#FF5252");
            }
            else if (_BMI.BMI <= 34)
            {
                ResBMI.Text = $"you are medium fat(degre2). BMI = {_BMI.BMI:F2}";
                ResBMI.TextColor = Color.FromHex("#C62828");
            }
            else if (_BMI.BMI <= 40)
            {
                ResBMI.Text = $"you are high fat(degre3). BMI = {_BMI.BMI:F2}";
                ResBMI.TextColor = Color.FromHex("#D50000");
            }
            else
            {
                ResBMI.Text = $"You are dngerous fat(mortal fat). BMI = {_BMI.BMI:F2}";
                ResBMI.TextColor = Color.FromHex("#900303");
            }



            string restext = string.Format("Based on your physical information and your weight status(BMI Degree),\nIf you have little physical activity(1 to 3 hour exercise in a week), you need {0:F2}(Cal=kcal) in a day.\nIf you have medium physical activity(3 to 5 time in week do exercise), you need {1:F2}(Cal=kcal) in a day.\nIf you have physical activity(daily exercise in week), you need {2:F2}(Cal=kcal) in a day.\nIf you have high physical activity(professional exercise), you need {3:F2}(Cal=kcal) in a day.", (_BMI.BMR * 1.375), (_BMI.BMR * 1.55), (_BMI.BMR * 1.725), (_BMI.BMR * 1.9));
            ResCal.TextColor = Color.FromHex("#281158");
            ResCal.Text = restext;
        }
        private void ShowBMINoResult()
        {
            ResCal.Text = "Enter your courent weight for calculate your BMI degree and see how much Calorie do you need in a day.";
            ResBMI.Text = "press + button,for Enter your new weight.";
        }

        private async void AddNewWeight_ClickedAsync(object sender, EventArgs e)
        {
            var BMIEntryP = new BMIEntryPage();
            BMIEntryP.WeightSet += this.OnWeightSet;
            await Navigation.PushModalAsync(BMIEntryP);
        }
    }
}