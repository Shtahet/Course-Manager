using CourseManager.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.BOL.Model
{
    public class ScheduleDTO
    {
        public int ScheduleID { get; set; }

        public int CoursID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public CourseDTO Course { get; set; }

        public static explicit operator ScheduleDTO(Schedule obj)
        {
            if (obj == null) return null;

            return new ScheduleDTO()
            {
                ScheduleID = obj.ScheduleID,
                CoursID = obj.CoursID,
                StartDate = obj.StartDate,
                EndDate = obj.EndDate,
                Course = (CourseDTO)obj.Course
            };

        }

        public static explicit operator Schedule (ScheduleDTO obj)
        {
            if (obj == null) return null;

            return new Schedule()
            {
                ScheduleID = obj.ScheduleID,
                CoursID = obj.CoursID,
                StartDate = obj.StartDate,
                EndDate = obj.EndDate
            };
        }
    }
}
