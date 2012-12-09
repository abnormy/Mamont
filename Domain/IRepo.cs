using System.Linq;

namespace Domain
{
    public interface IRepo<T> where T: Entity
    {
        IQueryable<T> GetAll();
        bool Save(T entity);
    }
}