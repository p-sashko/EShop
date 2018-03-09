﻿using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(int? id);

        IEnumerable<T> List();

        T Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
