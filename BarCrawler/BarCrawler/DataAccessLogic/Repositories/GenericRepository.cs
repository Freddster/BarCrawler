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
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="BarCrawler.DataAccessLogic.Repositories.Interface.IRepository{TEntity}" />
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        /// <summary>
        /// The context for a specific model which contains a table of data.
        /// </summary>
        protected DbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{TEntity}"/> class.
        /// </summary>
        public GenericRepository()
        {

        }

        /// <summary>
        /// The <see cref="context" /> for a specific model is being initiated.
        /// </summary>
        /// <param name="context">The context.</param>
        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        ///   <see cref="GetByID" /> is used to find a table from a model defined as TEntity through an id/&gt;.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public TEntity GetByID(int? id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        /// <summary>
        ///   <see cref="GetAll" /> is used to find all tables from a model defined as TEntity.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        /// <summary>
        ///   <see cref="Add" /> is used to add an entity to a specific models table where the entity could be a <see cref="BarModel" />.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        /// <summary>
        ///   <see cref="Remove" /> is used to remove an entity to a specific models table where the entity could be a <see cref="BarModel" />.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        ///   <see cref="MarkAsDirty" /> is used to indicate whenever an entity has changed
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected void MarkAsDirty(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}