
using SQLite;
using System;

namespace BMI.Models
{
    public class BMIs
    {
        [PrimaryKey, AutoIncrement, Column("ID")]
        public int ID { get; set; }
        [NotNull]
        public int UserID { get; set; }
        public DateTime time { get; set; }
        public Double BMI { get; set; }
        public Double BMR { get; set; }
        public Double weight { get; set; }
    }
}
