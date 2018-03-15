namespace CourseManager.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Courses")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            Schedules = new HashSet<Schedule>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int CoursID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(4000)]
        public string Description { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
