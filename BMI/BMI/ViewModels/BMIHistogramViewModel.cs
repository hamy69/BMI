using BMI.Models;
//using Microcharts;
//using SkiaSharp;
//using System;
using System.Collections.Generic;

namespace BMI.ViewModels
{
    public class BMIHistogramViewModel
    {
        public List<BMIs> BMIs;
        //public Entry[] BMIEntries;
        public BMIHistogramViewModel()
        {
            BMIs = new List<BMIs>();

            BMIs = App.Database.GetBMI(App.UserID);

            //BMIEntries = new Entry[BMIs.Count];
            //int count = -1;
            //foreach (BMIs bmi in BMIs)
            //{
            //    BMIEntries[++count] = new Entry(Convert.ToSingle(bmi.BMI))
            //    {
            //        Label = bmi.time.ToString(),
            //        ValueLabel = Convert.ToSingle(bmi.BMI).ToString(),
            //        Color = SKColor.Parse("#266489"),
            //        TextColor = SKColor.Parse("#266489")
            //    };
            //}
        }
        
    }
}
