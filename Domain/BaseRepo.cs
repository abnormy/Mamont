﻿using System;
using System.Linq;
using Entities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Domain
{
    public abstract class BaseRepo<T> : IRepo<T> where T : Entity
    {
        protected abstract string CollectionName { get; }

        private MongoCollection<T> GetCollection()
        {
            return MongoContext.Db.GetCollection<T>(CollectionName);
        }

        public void Save(T entity)
        {
            if (entity.Id == null) entity.Id = Guid.NewGuid().ToString();
            GetCollection().Save(entity);
        }

        public IQueryable<T> GetAll()
        {
            return GetCollection().AsQueryable();
        }
    }
}