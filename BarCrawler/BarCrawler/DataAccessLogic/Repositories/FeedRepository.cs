using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarCrawler.Models;

namespace DataAccessLogic.Repositories
{
    public class FeedRepository : IDisposable
    {
        private BarCrawlerContext _context;
        private DbSet<BarModel> _feedDbSet;

        /// <summary>
        /// This is the FeedRepository's constructor, where the dbset for FeedRepository are set. 
        /// The dbSet contains a table for all registred feeds in the project
        /// Initializes a new instance of the <see cref="FeedRepository"/> class.
        /// </summary>
        /// <param name="receivedContext">The received context.</param>
        public FeedRepository(BarCrawlerContext ReceivedContext)
        {
            _context = ReceivedContext;
            _feedDbSet = ReceivedContext.BarModels;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        //Find

        //Add

        //Delete

        //Remove
    }
}
