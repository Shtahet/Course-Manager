using CourseManager.BOL.Model;
using CourseManager.DAL.Abstract;
using CourseManager.DAL.Model;
using Sellers.BOL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CourseManager.BOL.Concrete
{
    class CourseDTOService : IBolService<CourseDTO>
    {
        private IGenericRepository<Course> courseRepo;

        public CourseDTOService(IGenericRepository<Course> DICourse)
        {
            courseRepo = DICourse;
        }
        public void AddOrUpdate(CourseDTO obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(CourseDTO obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseDTO> FindBy(Expression<Func<CourseDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public CourseDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseDTO> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
