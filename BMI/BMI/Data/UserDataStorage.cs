using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMI.Models;
using BMI.Persistence;
using SQLite;
using Xamarin.Forms;

namespace BMI.Data
{
    class UserDataStorage
    {
        public bool ExistDB = DependencyService.Get<ISQLiteDB>().CheckSQLiteDBExist();
        //conection String//##########################################################
        private SQLiteConnection _SQLiteConnection;
        public void UserDB()
        {
            _SQLiteConnection = DependencyService.Get<ISQLiteDB>().GetSQLiteConnection();
            _SQLiteConnection.CreateTable<Users>();
            //var t= _SQLiteConnection.FindWithQuery<Users>("select * from users where id == ?", "h");
        }

        public IEnumerable<Users> GetUsers()
        {
            return (from u in _SQLiteConnection.Table<Users>() 
                    select u).ToList();
        }
        public Users GetSpecificUser(int id)
        {
            return _SQLiteConnection.Table<Users>().FirstOrDefault(t => t.ID == id);
        }
        public void DeleteUser(int id)
        {
            _SQLiteConnection.Delete<Users>(id);
        }
        public string AddUser(Users user)
        {
            var data = _SQLiteConnection.Table<Users>();
            var d1 = data.Where(x => x.UserName == user.UserName && x.FullName == user.FullName).FirstOrDefault();

            if (d1 == null)
            {
                _SQLiteConnection.Insert(user);
                return "Sucessfully Added";
            }
            else
                return "Already Mail id Exist";
        
        }
        public bool updateUserValidation(string userid)
        {
            var data = _SQLiteConnection.Table<Users>();
            var d1 = (from values in data
                      where values.UserName == userid
                      select values).Single();

            if (d1 != null)
            {
                return true;
            }
            else
                return false;
        
        }
        public bool updateUser(string username, string pwd)
        {
            var data = _SQLiteConnection.Table<Users>();
            var d1 = (from values in data
                      where values.UserName == username
                      select values).Single();
            if (true)
            {
                d1.password = pwd;
                _SQLiteConnection.Update(d1);
                return true;
            }
            else
                return false;
        }
        public bool LoginValidate(string userName1, string pwd1)
        {
            var data = _SQLiteConnection.Table<Users>();
            var d1 = data.Where(x => x.UserName == userName1 && x.password == pwd1).FirstOrDefault();
            
            if (d1 != null)
            {
                return true;
            }
            else
                return false;
        
        }




        public int CheckUser(string UID, string PWD)
        {
            _SQLiteConnection.CreateTable<Users>();
            var table = _SQLiteConnection.FindWithQuery<Users>("SELECT * FROM users WHERE  UserName == ? AND password == ?", UID, PWD);
            foreach (var id in table.ID.ToString())
            {
                return Convert.ToInt16(id);
            }
            if (ExistDB)
            {
                //var table = connection
                return 1;
            }
            else
            {
                return -1;
            }
        }
        //Insert into SQL item//######################################################
        //Updates//###################################################################
        //Drop//######################################################################
    }
}
