using BarCrawler.Models;
using BarCrawler.ViewModels;

namespace BarCrawler.DataAccessLogic.Repositories.Interface
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
