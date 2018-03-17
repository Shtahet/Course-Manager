using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace CourseManager.WebUI.Models
{
    public class DayWeek
    {
        private DayOfWeek day;
        public int DayNumber
        {
            get { return (int)day; }
            set { day = (DayOfWeek)value; }
        }
        public string DayName
        {
            get { return Thread.CurrentThread.CurrentCulture.DateTimeFormat.GetDayName(day); }
            set { day = (DayOfWeek)Array.IndexOf(Thread.CurrentThread.CurrentCulture.DateTimeFormat.DayNames, value); }
        }
    }
}