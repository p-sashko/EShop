using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(Int32? id);

        IEnumerable<T> List(params Expression<Func<T, object>>[] includes);

        //IEnumerable<T> List();

        T Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        //void Include<TProperty>(Expression<Func<T, TProperty>> navigationPropertyPath);
    }
}
