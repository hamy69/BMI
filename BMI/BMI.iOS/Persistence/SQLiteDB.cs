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
            string path = Path.Combine(documentsPath, "Data");
            if (CheckSQLiteDBExist())
            {
                path = Path.Combine(path, "SQLite.db3");
            }
            else
            {
                CreateDB_folder_path(path);
                path = Path.Combine(path, "SQLite.db3");
            }
            SQLiteConnection connection = new SQLiteConnection(path);
            return connection;
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
        private void CreateDB_folder_path(string applicationFolderPath)
        {
            // Create the folder path.
            System.IO.Directory.CreateDirectory(applicationFolderPath);
        }
    }
}