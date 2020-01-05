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
using BMI.Droid.Persistence;
using Xamarin.Forms;
using SQLite;
using System.IO;
using BMI.Persistence;

[assembly: Dependency(typeof(SQLiteDB)) ]

namespace BMI.Droid.Persistence
{
    public class SQLiteDB : ISQLiteDB
    {
        private string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        public SQLiteConnection GetSQLiteConnection()
        {
            string path = Path.Combine(documentsPath, "Data/SQLite.db3");
            return new SQLiteConnection(path);
        }

        public bool CheckSQLiteDBExist()
        {
            string path = Path.Combine(documentsPath, "Data/SQLite.db3");
            if (System.IO.File.Exists(path))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
