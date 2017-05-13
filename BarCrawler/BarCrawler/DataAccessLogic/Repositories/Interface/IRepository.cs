using System.Collections.Generic;

namespace BarCrawler.DataAccessLogic.Repositories.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetByID(int? id);
        IEnumerable<TEntity> GetAll();
        void Remove(TEntity entity);
    }
}