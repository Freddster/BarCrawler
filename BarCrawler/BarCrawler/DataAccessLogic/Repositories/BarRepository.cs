using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BarCrawler.DataAccessLogic.Repositories;
using BarCrawler.Models;

namespace DataAccessLogic.Repositories
{
    public class BarRepository : GenericRepository<BarModel>, IBarRepository
    {
        private BarCrawlerContext _context;
        private DbSet<BarModel> _dbSet;

        public BarRepository(BarCrawlerContext receivedContext) : base(receivedContext)
        {
            _context = receivedContext;
            //_dbSet = receivedContext.BarModels;
        }

        public BarModel GetProfile(int? id)
        {
            return (_dbSet.Include(d => d.Drinks)
                .Include(e => e.Events)
                .Include(f => f.Feeds)
                .Include(p => p.Pictures)
                .SingleOrDefault(x => x.BarID == id));
        }
    }
}
