using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            set { startDate = startDate.AddHours(value); }
        }
        public int StartMinute
        {
            get { return startDate.Minute; }
            set { startDate = startDate.AddMinutes(value); }
        }
        public int EndHour
        {
            get { return endDate.Hour; }
            set { endDate = endDate.AddHours(value); }
        }
        public int EndMinute
        {
            get { return endDate.Minute; }
            set { endDate = endDate.AddMinutes(value); }
        }
        [Display(Name = "Время начала")]
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        [Display(Name = "Время окончания")]
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
        [Display(Name = "День занятий")]
        public int DayOfWeek
        {
            get { return (int)startDate.DayOfWeek; }
            set
            {
                startDate = startDate.AddDays(value);
                endDate = endDate.AddDays(value);
            }
        }
    }
}