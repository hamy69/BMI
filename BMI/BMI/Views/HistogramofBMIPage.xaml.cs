using BMI.ViewModels;
//using Microcharts;
//using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using Syncfusion;
using Syncfusion.SfChart.XForms;

namespace BMI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistogramofBMIPage : ContentPage
    {
        public HistogramofBMIPage()
        {
            InitializeComponent();
            //InitializaeChart();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            InitializaeChart();
        }
        private void InitializaeChart() 
        {
            BMIHistogramViewModel viewModel = new BMIHistogramViewModel();
            //this.BindingContext = viewModel.BMIs;

            //LineChart chart = new LineChart() { Entries = viewModel.BMIEntries };
            //this.chartView.Chart = chart;

            // Chart design
            this.sfCH.AreaBorderColor = Color.FromHex("#2196F3");
            this.sfCH.BackgroundColor = Color.Transparent;

            //Initializing primary axis
            CategoryAxis primaryAxis = new CategoryAxis();
            /*DateTime NowTime = DateTime.UtcNow;
            DateTimeAxis primaryAxis = new DateTimeAxis()
            {
                Minimum = new DateTime(NowTime.Year, NowTime.Month,NowTime.Day-15),
                Maximum = new DateTime(NowTime.Year, NowTime.Month, NowTime.Day+1) // last day in this mounth: DateTime.DaysInMonth(NowTime.Year, NowTime.Month)
            };*/

            primaryAxis.Title.Text = "Time";
            //primaryAxis.AxisLineStyle = ChartLineStyle.

            this.sfCH.PrimaryAxis = primaryAxis;

            //Initializing secondary Axis
            NumericalAxis secondaryAxis = new NumericalAxis();

            secondaryAxis.Title.Text = "Metric (Weight Kgr)";
            //secondaryAxis.AxisLineStyle


            this.sfCH.SecondaryAxis = secondaryAxis;

            //Initializing column series
            LineSeries BMI_series = new LineSeries();

            //series.SetBinding(ChartSeries.ItemsSourceProperty, "BMIs");
            BMI_series.ItemsSource = viewModel.BMIs;
            BMI_series.XBindingPath = "time";
            BMI_series.YBindingPath = "BMI";
            BMI_series.Color = Color.FromHex("#E040FB");
            BMI_series.Label = "BMI";

            BMI_series.DataMarker = new ChartDataMarker();
            BMI_series.EnableTooltip = true;

            BMI_series.StrokeDashArray = new double[2] { 2, 3 };
            //Enable animation for first BMI series in series collection.
            BMI_series.EnableAnimation = true;
            //BMI_series.AnimationDuration = 2;

            FastLineSeries Weight_series = new FastLineSeries();
            Weight_series.ItemsSource = viewModel.BMIs;
            Weight_series.XBindingPath = "time";
            Weight_series.YBindingPath = "weight";
            Weight_series.Label = "Weight";
            Weight_series.Color = Color.FromHex("#A0EE02");
            Weight_series.DataMarker = new ChartDataMarker();
            Weight_series.EnableTooltip = true;
            //Enable animation for first Weight series in series collection.
            Weight_series.EnableAnimation = true;


            this.sfCH.Legend = new ChartLegend(); // Shwo top serie Labels
            this.sfCH.Series.Clear(); // clear history when come reopen this page

            this.sfCH.Series.Add(BMI_series);
            this.sfCH.Series.Add(Weight_series);

            //// add Line Annotation to Axis
            //LineAnnotation annotation = new LineAnnotation();
            //annotation.X1 = 0;
            //annotation.Y1 = 50;
            //annotation.X2 = viewModel.BMIs.Count;
            //annotation.Y2 = 50;
            //annotation.StrokeColor = Color.FromHex("#FFFF00");
            //this.sfCH.ChartAnnotations.Add(annotation);

            // Zoom Behavior
            ChartZoomPanBehavior zoomPanBehavior = new ChartZoomPanBehavior();
            zoomPanBehavior.ZoomMode = ZoomMode.X;
            this.sfCH.ChartBehaviors.Add(zoomPanBehavior);

            // Selection
            this.sfCH.EnableSeriesSelection = true;
            this.sfCH.SeriesSelectionColor = Color.Red;

            //this.Content = sfCH;

        }
    }
}