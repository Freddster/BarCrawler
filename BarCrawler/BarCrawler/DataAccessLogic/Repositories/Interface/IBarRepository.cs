using BarCrawler.DataAccessLogic.Repositories.Interface;
using BarCrawler.Models;
using BarCrawler.ViewModels;

namespace DataAccessLogic.Repositories
{
    public interface IBarRepository : IRepository<BarModel>
    {
        BarModel GetProfile(int? id);
        BarModel GetEditInfo(int? id);
        void EditInfo(EditViewModel editviewmodel, BarModel bar);
        BarModel GetByUserID(string userId);
        void CreateAndAddBar(ref BarModel bar, ref BigRegisterViewModel model, ref ApplicationUser user);
    }
}
