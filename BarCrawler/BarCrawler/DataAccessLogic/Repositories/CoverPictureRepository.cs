using BarCrawler.Models;

namespace BarCrawler.DataAccessLogic.Repositories.Interface
{
    public class CoverPictureRepository : GenericRepository<CoverPictureModel>, ICoverPictureRepository
    {
        public CoverPictureRepository(BarCrawlerContext ReceivedContext) : base(ReceivedContext)
        {
        }
    }
}