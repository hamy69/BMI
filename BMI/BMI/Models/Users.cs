using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BMI.Models
{
    class Users
    {
        [PrimaryKey, AutoIncrement, Column("ID")]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string password { get; set; }
        public string FullName { get; set; }
        public DateTime birthdate { get ; set; }
        public int length { get; set; }
        public string ImageUrl { get; set; }

    }
}
