using CourseManager.BOL.Model;
using CourseManager.DAL.Abstract;
using CourseManager.DAL.Model;
using Sellers.BOL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.BOL.Concrete
{
    public class ScheduleDTOService : IBolService<ScheduleDTO>
    {
        IGenericRepository<Schedule> scheduleRepo;
        public ScheduleDTOService(IGenericRepository<Schedule> DISchedule)
        {
            scheduleRepo = DISchedule;
        }
        public void AddOrUpdate(ScheduleDTO obj)
        {
            scheduleRepo.AddOrUpdate((Schedule)obj);
        }

        public void Delete(int id)
        {
            scheduleRepo.Delete(id);
        }

        public IEnumerable<ScheduleDTO> FindBy(Expression<Func<ScheduleDTO, bool>> predicate)
        {
            Expression<Func<Schedule, bool>> expressionDAL = ConvertTypeExpression.ConvertType<ScheduleDTO, Schedule>(predicate.Body);
            return scheduleRepo.FindBy(expressionDAL).ToList().Select(s => (ScheduleDTO)s);
        }

        public ScheduleDTO Get(int id)
        {
            return (ScheduleDTO)scheduleRepo.Get(id);
        }

        public IEnumerable<ScheduleDTO> GetAll()
        {
            return scheduleRepo.GetAll().ToList().Select(s => (ScheduleDTO)s);
        }
    }
}
