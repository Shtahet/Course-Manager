using CourseManager.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.DAL.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        DbContext context;
        DbSet<T> dbSet;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
        public void AddOrUpdate(T obj)
        {
            dbSet.AddOrUpdate(obj);
            context.SaveChanges();
        }

        public void Delete(int key)
        {
            T ObjectEF = dbSet.Find(key);
            dbSet.Remove(ObjectEF);
            context.SaveChanges();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public T Get(int key)
        {
            return dbSet.Find(key);
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }
    }
}
