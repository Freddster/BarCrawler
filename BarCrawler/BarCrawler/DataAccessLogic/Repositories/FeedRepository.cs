using BarCrawler.DataAccessLogic.Repositories.Interface;
using BarCrawler.Models;

namespace BarCrawler.DataAccessLogic.Repositories
{
    /// <summary>
    /// The FeedRepository is making sure to update the correct tables in case of any changes
    /// </summary>
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
