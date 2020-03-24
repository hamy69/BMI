using BMI.Data;
using BMI.Models;
using BMI.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BMI
{
    public partial class App : Application
    {
        static UserDatabase database;
        public static UserDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new UserDatabase(DBPath);
                }
                return database;
            }
        }
        static Users user;
        public static Users User
        {
            get
            {
                if (UserID >= 0)
                    user = Database.GetUser(UserID);
                return user;
            }
        }

        public static string CacheFolderPath { get; private set; }
        public static string AppDataFolderPath { get; private set; }
        public static string FolderPath { get; private set; }
        public static string DBPath { get; private set; }
        public static string CachePath { get; private set; }
        public static int UserID { get; set; }

        private bool LogCacheFlag = false;
        public App()
        {
            InitializeComponent();
            WarmUpParameters();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            if (!LogCacheFlag)
                MainPage = new NavigationPage(new LogingPage());
            else
                MainPage = new AppShell();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private void WarmUpParameters()
        {
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

            //Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            // Get the path to a file on internal storage
            AppDataFolderPath = Xamarin.Essentials.FileSystem.AppDataDirectory; //backingFile
            // Get the path to a file in the cache directory
            CacheFolderPath = Xamarin.Essentials.FileSystem.CacheDirectory;

            DBPath = Path.Combine(AppDataFolderPath, "Data/SQLite.db3");
            // Delete the folder path.
            //File.Delete(DBPath);
            //Directory.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Data"));
            // Create the folder path.
            if (!File.Exists(DBPath))
                Directory.CreateDirectory(Path.Combine(AppDataFolderPath, "Data"));

            //check loging cache is exist and reading that
            CachePath = (Path.Combine(CacheFolderPath, "LogInfo.txt"));
            if (File.Exists(CachePath))
            {
                LogCacheFlag = true;
                // set UserID
                string[] _Cache = File.ReadAllLines(CachePath);
                var _Time = _Cache[0];
                UserID = Convert.ToInt32(_Cache[1]);
            }
        }
    }
}
