using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarCrawler.Models;

namespace DataAccessLogic.Repositories
{
    public class PictureRepository : IDisposable
    {
        private BarCrawlerContext _context;
        private DbSet<BarModel> _pictureDbSet;

        /// <summary>
        /// This is the PictureRepository's constructor, where the dbset for PictureRepository are set. 
        /// The dbSet contains a table for all registred pictures in the project
        /// Initializes a new instance of the <see cref="PictureRepository"/> class.
        /// </summary>
        /// <param name="receivedContext">The received context.</param>
        public PictureRepository(BarCrawlerContext ReceivedContext)
        {
            _context = ReceivedContext;
            _pictureDbSet = ReceivedContext.BarModels;
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
