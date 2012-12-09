using System;
using System.Linq;

namespace Domain
{
    public class BaseRepo<T> : IRepo<T> where T : Entity
    {
        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
