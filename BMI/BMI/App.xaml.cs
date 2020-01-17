using BMI.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BMI
{
    public partial class App : Application
    {
        public static string CacheFolderPath { get; private set; }
        public static string AppDataFolderPath { get; private set; }
        public static string FolderPath { get; private set; }
        public App()
        {
            InitializeComponent();
            //FolderPath = Environment.CurrentDirectory;
            //FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            //FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
            //FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            //FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            //FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
            //FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            //FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));
            //FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            //FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            //FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            
            FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            // Get the path to a file on internal storage
            AppDataFolderPath = Xamarin.Essentials.FileSystem.AppDataDirectory; //backingFile
            // Get the path to a file in the cache directory
            CacheFolderPath = Xamarin.Essentials.FileSystem.CacheDirectory;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            MainPage = new NavigationPage(new LogingPage());
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
