using BMI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BMI.ViewModels
{
    public class calorieViewModel
    {
        public List<Calories> CaloriesPerDay;
        public calorieViewModel()
        {
            CaloriesPerDay = new List<Calories>();
            List<Calories> DataCalories = App.Database.GetCalories(App.UserID);

            Calories SumCalories = new Calories();
            DateTime Preday = new DateTime();
            foreach (Calories Calorie in DataCalories)
            {
                DateTime day = new DateTime(Calorie.time.Year, Calorie.time.Month, Calorie.time.Day);
                if (Preday == day)
                {
                    // sum all calorie in a day
                    SumCalories.Calorie += Calorie.Calorie;
                }
                else
                {
                    // add pre day calorie to CaloriesPerDay list
                    if (SumCalories.Calorie > 0) // at firt loop day calorie equal to 0
                        CaloriesPerDay.Add(SumCalories);
                    // create new object
                    SumCalories = new Calories();
                    SumCalories.UserID = Calorie.UserID;
                    SumCalories.Calorie = Calorie.Calorie;
                    SumCalories.time = day;

                    Preday = day;
                }
            }
            CaloriesPerDay.Add(SumCalories); // add last loop calorie sumation
        }
    }
}
