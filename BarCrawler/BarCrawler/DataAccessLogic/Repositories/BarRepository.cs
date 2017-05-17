using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BarCrawler.Models;

namespace DataAccessLogic.Repositories
{

    /// <summary>
    /// The BarRepository contains the different functions to find all or a specific bar
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class BarRepository : IDisposable
    {
        private BarCrawlerContext _context;
        private DbSet<BarModel> _dbSet;

        /// <summary>
        /// This is the BarRepository's constructor, where the dbset for BarRepository are set. 
        /// The dbSet contains a table for all registred bar profiles in the project
        /// Initializes a new instance of the <see cref="BarRepository"/> class.
        /// </summary>
        /// <param name="receivedContext">The received context.</param>
        public BarRepository(BarCrawlerContext receivedContext)
        {
            _context = receivedContext;
            _dbSet = receivedContext.BarModels;
        }

        /// <summary>
        /// Gets all bars in the dbSet for BarRepository.
        /// </summary>
        /// <param name="GetAllBars">GetAllBars</param>
        /// <returns></returns>
        public IEnumerable<BarModel> GetAllBars()
        {
            return _dbSet.ToList();
        }

        /// <summary>
        /// Gets a bar by it's ID from the dbSet
        /// </summary>
        /// <param name="GetBarByID">GetBarByID</param>
        /// <returns></returns>
        /// 
        public BarModel GetBarByID(int? id) //int? is nullable. int is not
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// Gets the complete profile for a bar, which mean the bar's events, feeds, pictures and drinks.
        /// </summary>
        /// <param name="GetProfile">GetProfile</param>
        /// <returns></returns>
        public BarModel GetProfile(int? id)
        {
            return (_dbSet.Include(d => d.Drinks)
                .Include(e => e.Events)
                .Include(f => f.Feeds)
                .Include(p => p.Pictures)
                .SingleOrDefault(x => x.BarID == id));
        }


        /// <summary>
        /// Adds a new bar to the dbSet of BarRepository.
        /// </summary>
        /// <param name="barModel">Add a new bar.</param>
        public void AddBar(BarModel barModel)
        {
            _dbSet.Add(barModel);
        }


        /// <summary>
        /// Deletes a bar from the dbSet
        /// </summary>
        /// <param name="DeleteBar">Deletes a Bar</param>
        public void DeleteBar(int? barModelID)
        {
            BarModel barModel = _dbSet.Find((barModelID));
            if (barModel != null)
                _dbSet.Remove(barModel);
        }


        /// <summary>
        /// Updates the bar model.
        /// </summary>
        /// <param name="barModel">Updates a Bar</param>
        public void UpdateBarModel(BarModel barModel)
        {
            _context.Entry(barModel).State = EntityState.Modified;
        }


        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
