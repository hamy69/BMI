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
            string path = Path.Combine(documentsPath, "Data");
            if (CheckSQLiteDBExist())
            {
                
                path = Path.Combine(path, "SQLite.db3");
                //DeleteDB(path);

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
        private void DeleteDB(string DBPath)
        {
            // Delete the folder path.
            System.IO.File.Delete(DBPath);
        }
    }
}
