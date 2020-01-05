using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BMI.iOS.Persistence;
using BMI.Persistence;
using Foundation;
using SQLite;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDB))]

namespace BMI.iOS.Persistence
{
    public class SQLiteDB : ISQLiteDB
    {
        private string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        public SQLiteConnection GetSQLiteConnection()
        {
            var path = Path.Combine(documentsPath, "Data/SQLite.db3");

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