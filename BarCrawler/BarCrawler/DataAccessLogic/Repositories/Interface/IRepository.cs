using System.Collections.Generic;

namespace BarCrawler.DataAccessLogic.Repositories.Interface
{
    /// <summary>
    /// Interface for the generic repositoiry to implement.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets the TEntity by identifier, in the database.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Returns the <see cref="IRepository{TEntity}">TEntity</see>
        /// </returns>
        TEntity GetByID(int? id);

        /// <summary>
        /// Gets all the TEntities in the database.
        /// </summary>
        /// <returns>
        /// Returns the <see cref="IRepository{TEntity}">TEntity</see> contained in a generic container
        /// </returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Adds the specified entity to the database.
        /// </summary>
        /// <param name="entity">The entity to add to the database.</param>
        void Add(TEntity entity);

        /// <summary>
        /// Removes the specified entity from the database.
        /// </summary>
        /// <param name="entity">The entity to remove from the database.</param>
        void Remove(TEntity entity);
    }
}