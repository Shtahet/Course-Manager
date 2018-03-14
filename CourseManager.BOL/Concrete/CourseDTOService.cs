using CourseManager.BOL.Model;
using CourseManager.DAL.Abstract;
using CourseManager.DAL.Model;
using Sellers.BOL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CourseManager.BOL.Concrete
{
    public class CourseDTOService : IBolService<CourseDTO>
    {
        private IGenericRepository<Course> courseRepo;

        public CourseDTOService(IGenericRepository<Course> DICourse)
        {
            courseRepo = DICourse;
        }
        public void AddOrUpdate(CourseDTO obj)
        {
            courseRepo.AddOrUpdate((Course)obj);
        }

        public void Delete(CourseDTO obj)
        {
            courseRepo.Delete((Course)obj);
        }

        public IEnumerable<CourseDTO> FindBy(Expression<Func<CourseDTO, bool>> predicate)
        {
            Expression<Func<Course, bool>> predicateDAL = ConvertTypeExpression.ConvertType<CourseDTO, Course>(predicate.Body);
            return courseRepo.FindBy(predicateDAL).ToList().Select(c => (CourseDTO)c);
        }

        public CourseDTO Get(int id)
        {
            return (CourseDTO)courseRepo.Get(id);
        }

        public IEnumerable<CourseDTO> GetAll()
        {
            return courseRepo.GetAll().ToList().Select(c => (CourseDTO)c);
        }
    }
}
