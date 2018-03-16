using CourseManager.DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.BOL.Model
{
    public class CourseDTO
    {
        public int CoursID { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Название курса")]
        public string Name { get; set; }

        [StringLength(4000)]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Стоимость")]
        [Range(0.001d,Double.MaxValue, ErrorMessage = "Стоимость курса должна быть больше нуля")]
        public decimal Price { get; set; }

        public static explicit operator CourseDTO(Course obj)
        {
            if (obj == null) return null;

            return new CourseDTO()
            {
                CoursID = obj.CoursID,
                Name = obj.Name,
                Description = obj.Description,
                Price = obj.Price
            };
        }

        public static explicit operator Course (CourseDTO obj)
        {
            if (obj == null) return null;

            return new Course()
            {
                CoursID = obj.CoursID,
                Name = obj.Name,
                Description = obj.Description,
                Price = obj.Price
            };
        }
    }
}
