using Autofac;
using System.Data.Entity;
using CourseManager.DAL.Model;
using CourseManager.DAL.Abstract;
using CourseManager.DAL.Concrete;
using CourseManager.BOL.Model;
using Sellers.BOL.Abstract;
using CourseManager.BOL.Concrete;

namespace CourseManager.WebUI.Infrastructure
{
    public class AutofacConfigModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(CourseContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerRequest();
            builder.RegisterType(typeof(CourseDTOService)).As(typeof(IBolService<CourseDTO>)).InstancePerRequest();
            builder.RegisterType(typeof(CourseDTOService)).As(typeof(IBolService<ScheduleDTO>)).InstancePerRequest();
            base.Load(builder);
        }
    }
}