using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading;

namespace BMI.Droid
{
    [Activity(Label = "BMI", Icon = "@mipmap/icon", Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory =true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SplashLayout);

            // Create your application here
            StartActivity(typeof(MainActivity));
        }
    }
}