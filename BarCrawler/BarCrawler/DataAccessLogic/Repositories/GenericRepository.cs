using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using BarCrawler.DataAccessLogic.Repositories.Interface;
using BarCrawler.Models;


namespace BarCrawler.DataAccessLogic.Repositories
{
    /// <summary>
    /// Most of the repositories share some of the same functionality, and therefore there has been created a GenericRepository for those functions.
    /// </summary>
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        /// <summary>
        /// The context for a specific model which contains a table of data.
        /// </summary>
        protected DbContext _context;

        public GenericRepository()
        {

        }

        /// <summary>
        /// The <see cref="context"/> for a specific model is being initiated.
        /// </summary>
        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// <see cref="GetByID"/> is used to find a table from a model defined as TEntity through an id/>.
        /// </summary>
        public TEntity GetByID(int? id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// <see cref="GetAll"/> is used to find all tables from a model defined as TEntity.
        /// </summary>
        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        /// <summary>
        /// <see cref="Add"/> is used to add an entity to a specific models table where the entity could be a <see cref="BarModel"/>.
        /// </summary>
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// <see cref="Remove"/> is used to remove an entity to a specific models table where the entity could be a <see cref="BarModel"/>.
        /// </summary>
        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// <see cref="MarkAsDirty"/> is used to indicate whenever an entity has changed
        /// </summary>
        protected void MarkAsDirty(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}