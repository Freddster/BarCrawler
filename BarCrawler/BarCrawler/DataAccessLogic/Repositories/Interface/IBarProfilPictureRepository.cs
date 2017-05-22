using BarCrawler.Models;
using BarCrawler.ViewModels;

namespace BarCrawler.DataAccessLogic.Repositories.Interface
{
    public interface IBarProfilPictureRepository : IRepository<BarProfilePictureModel>
    {
        void AddModelForUpdate(ref PictureViewModel viewModel, ref BarProfilePictureModel pictureModel);
    }
}