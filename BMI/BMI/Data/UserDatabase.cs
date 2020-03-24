using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using BMI.Models;
using System;

namespace BMI.Data
{
    public class UserDatabase
    {
        readonly SQLiteConnection _database;

        public UserDatabase(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<Users>();
            _database.CreateTable<BMIs>();
            _database.CreateTable<Calories>();
        }

        public List<Users> GetUser()
        {
            return _database.Table<Users>().ToList();
        }

        public Users GetUser(int id)
        {
            return _database.Table<Users>().Where(i => i.ID == id).FirstOrDefault();
        }
        public Users GetUser(string userName)
        {
            return _database.Table<Users>().Where(i => i.UserName == userName).FirstOrDefault();
        }

        public string SaveUser(Users user)
        {
            if (user.ID != 0)
            {
                int res = _database.Update(user);
                return "Sucessfully Update";
            }
            else
            {
                Users d1 = _database.Table<Users>().Where(i => i.UserName == user.UserName).FirstOrDefault();
                if (d1 == null)
                {
                    _database.Insert(user);
                    return "Sucessfully Added";
                }
                else
                {
                    return "Already Mail id Exist";
                }
            }
        }
        public int DeleteUser(Users user)
        {
            return _database.Delete(user);
        }
        public bool LoginValidateAsync(string userName, string pwd)
        {
            Users d1 = _database.Table<Users>().Where(i => i.UserName == userName && i.password == pwd).FirstOrDefault();
            if (d1 == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //------------------------ BMI:
        public List<BMIs> GetBMI()
        {
            return _database.Table<BMIs>().ToList();
        }
        public List<BMIs> GetBMI(int UserId)
        {
            return _database.Table<BMIs>().Where(i => i.UserID == UserId).ToList();
        }
        public BMIs GetLastBMI(int UserId)
        {
            List<BMIs> ListBMIs = _database.Table<BMIs>().Where(i => i.UserID == UserId).ToList();
            return ListBMIs[ListBMIs.Count - 1];
        }
        public string AddBMI (BMIs BMI)
        {
            try
            {
                _database.Insert(BMI);
                return "Sucessfully Added";
            }
            catch (Exception e)
            {
                return $"Error :{e.Message}";
            }
        }

        //------------------------ Calorie:
        public List<Calories> GetCalories (int UserId)
        {
            return _database.Table<Calories>().Where(i => i.UserID == UserId).ToList();
        }
        public int GetSumDayCalorie(int UserId, DateTime day)
        {
            List<Calories> calories = _database.Table<Calories>().Where(i => i.UserID == UserId).ToList();
            int sum = 0;
            foreach (Calories cal in calories)
            {
                if(cal.time.Year == day.Year && cal.time.Month == day.Month && cal.time.Day == day.Day)
                    sum += cal.Calorie;
            }
            return sum;
        }
        public string AddCalorie (Calories Cal)
        {
            try
            {
                _database.Insert(Cal);
                return "Sucessfully Added";
            }
            catch (Exception e)
            {
                return $"Error :{e.Message}";
            }
        }

        /*
        public bool ExistDB = DependencyService.Get<ISQLiteDB>().CheckSQLiteDBExist();
        //conection String//##########################################################
        private SQLiteConnection _SQLiteConnection = DependencyService.Get<ISQLiteDB>().GetSQLiteConnection();
        public void UserDB()
        {
            //_SQLiteConnection = DependencyService.Get<ISQLiteDB>().GetSQLiteConnection();
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
        public Users GetSpecificUser(string userName)
        {
            return _SQLiteConnection.Table<Users>().FirstOrDefault(t => t.UserName == userName);
        }
        public void DeleteUser(int id)
        {
            _SQLiteConnection.Delete<Users>(id);
        }
        public string AddUser(Users user)
        {
            TableQuery<Users> data = _SQLiteConnection.Table<Users>();
            Users d1 = data.Where(x => x.UserName == user.UserName && x.FullName == user.FullName).FirstOrDefault();

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
            TableQuery<Users> data = _SQLiteConnection.Table<Users>();
            Users d1 = (from values in data
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
            TableQuery<Users> data = _SQLiteConnection.Table<Users>();
            Users d1 = (from values in data
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
        public bool LoginValidate(string userName, string pwd)
        {
            TableQuery<Users> data = _SQLiteConnection.Table<Users>();
            Users d1 = data.Where(x => x.UserName == userName && x.password == pwd).FirstOrDefault();
            
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
            Users table = _SQLiteConnection.FindWithQuery<Users>("SELECT * FROM users WHERE  UserName == ? AND password == ?", UID, PWD);
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
        */
    }
}
