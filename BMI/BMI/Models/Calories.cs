using SQLite;
using System;

namespace BMI.Models
{
    public class Calories
    {
        [PrimaryKey, AutoIncrement, Column("ID")]
        public int ID { get; set; }
        [NotNull]
        public int UserID { get; set; }
        public DateTime time { get; set; }
        public int Calorie { get; set; }
    }
}
