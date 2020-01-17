using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BMI.Behaviors
{
    class DateValidationBehavior : Behavior<DatePicker>
    {
        protected override void OnAttachedTo(DatePicker bindable)
        {
            bindable.DateSelected += Datepicker_DateSelected;
            base.OnAttachedTo(bindable);
        }

        private void Datepicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            bool isValid = false;
            if ((DateTime.Now.Year- e.NewDate.Year) <= 100 && (DateTime.Now.Year - e.NewDate.Year) > 0)
            {
                isValid = true;
            }
           ((DatePicker)sender).BackgroundColor = isValid ? Color.Default : Color.Red;
        }
        protected override void OnDetachingFrom(DatePicker bindable)
        {
            bindable.DateSelected -= Datepicker_DateSelected;
            base.OnDetachingFrom(bindable);
        }
    }
}
