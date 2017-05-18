using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarCrawler.DataAccessLogic.Repositories;
using BarCrawler.DataAccessLogic.Repositories.Interface;
using BarCrawler.Models;

namespace DataAccessLogic.Repositories
{
    public class FeedRepository : GenericRepository<FeedModel>, IFeedRepository
    {
        public FeedRepository(BarCrawlerContext receivedContext) : base(receivedContext)
        {
        }

        public BarCrawlerContext BarCrawlerContext
        {
            get { return _context as BarCrawlerContext; }
        }
    }
}
