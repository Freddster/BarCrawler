using BarCrawler.DataAccessLogic.Repositories.Interface;
using BarCrawler.Models;

namespace DataAccessLogic.Repositories
{
    public interface IBarRepository : IRepository<BarModel>
    {
        BarModel GetProfile(int? id);
    }
}
