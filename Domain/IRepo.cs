﻿using System.Linq;
using Entities;

namespace Domain
{
    public interface IRepo<T> where T: Entity
    {
        void Save(T entity);
        IQueryable<T> GetAll();
    }
}