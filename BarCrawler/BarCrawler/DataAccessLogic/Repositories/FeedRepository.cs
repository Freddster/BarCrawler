using BarCrawler.DataAccessLogic.Repositories.Interface;
using BarCrawler.Models;

namespace BarCrawler.DataAccessLogic.Repositories
{
    /// <summary>
    /// The FeedRepository contains functions to store, edit and get the correct feeds from the database.
    /// </summary>
    /// <seealso cref="FeedModel" />
    /// <seealso cref="IFeedRepository" />
    public class FeedRepository : GenericRepository<FeedModel>, IFeedRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeedRepository" /> class.
        /// </summary>
        /// <param name="receivedContext">The received context.</param>
        /// <seealso cref="BarCrawlerContext" />
        public FeedRepository(BarCrawlerContext receivedContext) : base(receivedContext)
        {
        }

        /// <summary>
        /// Gets the bar crawler context.
        /// </summary>
        /// <value>
        /// The bar crawler context.
        /// </value>
        /// <seealso cref="BarCrawlerContext"/>
        public BarCrawlerContext BarCrawlerContext
        {
            get { return _context as BarCrawlerContext; }
        }
    }
}
