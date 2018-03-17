using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseManager.WebUI.Models
{
    public class WebSchedule
    {
        private DateTime startDate;
        private DateTime endDate;
        public int ScheduleID { get; set; }
        public int CoursID { get; set; }
        public int StartHour
        {
            get { return startDate.Hour; }
            set { startDate.AddHours(value); }
        }
        public int StartMinute
        {
            get { return startDate.Minute; }
            set { startDate.AddMinutes(value); }
        }
        public int EndHour
        {
            get { return endDate.Hour; }
            set { endDate.AddHours(value); }
        }
        public int EndMinute
        {
            get { return endDate.Minute; }
            set { endDate.AddMinutes(value); }
        }
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
        public int DayOfWeek
        {
            get { return (int)startDate.DayOfWeek; }
            set
            {
                startDate.AddDays(value);
                endDate.AddDays(value);
            }
        }
    }
}