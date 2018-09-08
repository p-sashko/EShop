using EShop.Infrastructure;
using EShop.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Entities;
using System.Linq.Expressions;
using System;

namespace Infrastructure.Data
{
    /// <summary>
    /// "There's some repetition here - couldn't we have some the sync methods call the async?"
    /// https://blogs.msdn.microsoft.com/pfxteam/2012/04/13/should-i-expose-synchronous-wrappers-for-asynchronous-methods/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly EShopContext _dbContext;

        public EfRepository(EShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetById(int? id)
        {
            if(!id.HasValue)
            {
                return default(T);
            }

            return _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public IEnumerable<T> List(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);

            return query.ToList();
        }

        //public IEnumerable<T> List()
        //{
        //    return _dbContext.Set<T>().ToList();
        //}

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        //public void Include<TProperty>(Expression<Func<T, TProperty>> navigationPropertyPath)
        //{
        //    _dbContext.Set<T>() = _dbContext.Set<T>().Include(navigationPropertyPath);
        //}

    }
}
