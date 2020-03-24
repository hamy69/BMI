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
using Android.Util;
using System.Threading.Tasks;
using Android.Support.V7.App;
using Android.Views.Animations;

namespace BMI.Droid
{
    [Activity(Label = "@string/app_name", Icon = "@mipmap/icon", Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {

        ImageView imageView;
        TextView textView;

        static readonly string TAG = "X:" + typeof(SplashActivity).Name;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Log.Debug(TAG, "SplashActivity.OnCreate");
            SetContentView(Resource.Layout.SplashLayout);
            imageView = (ImageView)FindViewById(Resource.Id.imageView1);
            textView = (TextView)FindViewById(Resource.Id.textView1);

            // Create your application here
            //StartActivity(typeof(MainActivity));
        }

        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();

            Animation fadeIn_animation = AnimationUtils.LoadAnimation(this, Resource.Animation.Animation_fadeIn);
            imageView.StartAnimation(fadeIn_animation);
            fadeIn_animation.AnimationEnd += fadeIn_AnimationEnd;
            Animation SlideIn_animation = AnimationUtils.LoadAnimation(this, Resource.Animation.Animation_SlideIn);
            textView.StartAnimation(SlideIn_animation);
            SlideIn_animation.AnimationEnd += SlideIn_AnimationEnd;
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }
        private void fadeIn_AnimationEnd(object sender, Animation.AnimationEndEventArgs e)
        {
            //Task startupWork = new Task(() => { SimulateStartup(); });
            //startupWork.Start();
            Finish();
        }
        private void SlideIn_AnimationEnd(object sender, Animation.AnimationEndEventArgs e)
        {
            Finish();
        }

        // Prevent the back button from canceling the startup process
        public override void OnBackPressed() { }

        // Simulates background work that happens behind the splash screen
        async void SimulateStartup()
        {
            Log.Debug(TAG, "Performing some startup work that takes a bit of time.");
            await Task.Delay(1880); // Simulate a bit of startup work.
            Log.Debug(TAG, "Startup work is finished - starting MainActivity.");
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}