namespace CourseManager.DAL.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CourseContext : DbContext
    {
        public CourseContext()
            : base("name=CourseContext")
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Schedules)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);
        }
    }
}
