using BMI.Models;
using BMI.ViewModels;
using Syncfusion.SfChart.XForms;
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
    public partial class caloriePage : ContentPage
    {
        Double _BetaMultiplier = 1.55; // Medium Active
        public caloriePage()
        {
            InitializeComponent();
            var DayRes_tap = new TapGestureRecognizer();
            DayRes_tap.Tapped += (s, e) =>
            {
                AddNewCalorie_Clicked(s, e);
            };
            DayRes.GestureRecognizers.Add(DayRes_tap);
            DayVisulize();
        }

        private async void AddNewCalorie_Clicked(object sender, EventArgs e)
        {
            // Create Calorie model for add to Database
            Calories calorie = new Calories();
            calorie.UserID = App.UserID;
            calorie.time = DateTime.UtcNow;
            string Cal = await DisplayPromptAsync("Add Calorie", "How much Calorie eat in your courent meal?", "Add", "Cancel", "Kilo Calorie", 4, Keyboard.Numeric);
            calorie.Calorie = Convert.ToInt32(Cal);
            // Add to database
            App.Database.AddCalorie(calorie);
            // Show result of new sumerize
            DayVisulize();
        }
        private void DayVisulize()
        {
            // show title sumition of today calorie ate
            DayRes.Text = App.Database.GetSumDayCalorie(App.UserID, DateTime.UtcNow).ToString();
            // show charts of a week calorie
            calorieViewModel _calorieViewModel = new calorieViewModel();

            // Chart design
            this.sfCH.AreaBorderColor = Color.FromHex("#2196F3");
            this.sfCH.BackgroundColor = Color.Transparent;

            //Initializing primary axis
            DateTime NowTime = DateTime.UtcNow;
            TimeSpan tSpan15 = new TimeSpan(15, 0, 0, 0);
            TimeSpan tSpan1 = new TimeSpan(1, 0, 0, 0);

            DateTimeAxis primaryAxis = new DateTimeAxis()
            {
                Minimum = NowTime - tSpan15,
                Maximum = NowTime + tSpan1 // last day in this mounth: DateTime.DaysInMonth(NowTime.Year, NowTime.Month)
            };
            primaryAxis.Title.Text = "Time";
            this.sfCH.PrimaryAxis = primaryAxis;

            //Initializing secondary Axis
            NumericalAxis secondaryAxis = new NumericalAxis();
            secondaryAxis.Title.Text = "Calorie (in KCal)";
            this.sfCH.SecondaryAxis = secondaryAxis;

            //Initializing column series
            ColumnSeries series = new ColumnSeries();
            series.ItemsSource = _calorieViewModel.CaloriesPerDay;
            series.XBindingPath = "time";
            series.YBindingPath = "Calorie";
            series.Label = "BMI";

            series.DataMarker = new ChartDataMarker();
            series.EnableTooltip = true;

            //Enable animation for first series in series collection.
            series.EnableAnimation = true;

            this.sfCH.Legend = new ChartLegend(); // Shwo top serie Labels
            this.sfCH.Series.Clear(); // clear history when come reopen this page

            this.sfCH.Series.Add(series);

            // add Line Annotation to Axis
            LineAnnotation annotation = new LineAnnotation();
            annotation.X1 = NowTime - tSpan15;
            annotation.Y1 = GetCalorieBMR();
            annotation.X2 = NowTime + tSpan1;
            annotation.Y2 = annotation.Y1;
            annotation.StrokeColor = Color.FromHex("#D50000");
            annotation.StrokeWidth = 5;
            this.sfCH.ChartAnnotations.Clear();
            this.sfCH.ChartAnnotations.Add(annotation);

            // Zoom Behavior
            ChartZoomPanBehavior zoomPanBehavior = new ChartZoomPanBehavior();
            zoomPanBehavior.ZoomMode = ZoomMode.X;
            this.sfCH.ChartBehaviors.Add(zoomPanBehavior);

            // Selection
            this.sfCH.EnableSeriesSelection = true;
            this.sfCH.SeriesSelectionColor = Color.Red;

            //this.Content = sfCH;
        }

        private Double GetCalorieBMR()
        {
            List<BMIs> _BMIs = App.Database.GetBMI(App.UserID);
            if (_BMIs.Count > 0)
            {
                BMIs _BMI = _BMIs[_BMIs.Count - 1];
                return (_BMI.BMR * _BetaMultiplier);
            }
            else
            {
                return 0;// dont have BMR
            }
        }

        private void ActivityPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (((Picker)sender).SelectedIndex)
            {
                case 0:
                    _BetaMultiplier = 1.375;
                    break;
                case 1:
                    _BetaMultiplier = 1.55;
                    break;
                case 2:
                    _BetaMultiplier = 1.725;
                    break;
                case 3:
                    _BetaMultiplier = 1.9;
                    break;
            }
            DayVisulize();

            //_BMI.BMR* 1.375), (_BMI.BMR* 1.55), (_BMI.BMR* 1.725), (_BMI.BMR* 1.9)
        }
    }
}