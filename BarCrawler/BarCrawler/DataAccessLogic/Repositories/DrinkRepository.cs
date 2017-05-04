using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarCrawler.Models;

namespace DataAccessLogic.Repositories
{
    public class DrinkRepository : IDisposable
    {
        private BarCrawlerContext _context;
        private DbSet<BarModel> _dbSet;

        public DrinkRepository(BarCrawlerContext ReceivedContext)
        {
            _context = ReceivedContext;
            _dbSet = ReceivedContext.BarModels;
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
