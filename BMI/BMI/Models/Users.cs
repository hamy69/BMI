using SQLite;
using System;

namespace BMI.Models
{
    public class Users
    {
        [PrimaryKey, AutoIncrement, Column("ID")]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string password { get; set; }
        public string FullName { get; set; }
        public int Gender { get; set; } // 1.Male 2.Female 3.Other
        public DateTime birthdate { get ; set; }
        public int length { get; set; }
        public string ImageUrl { get; set; }
    }
}
