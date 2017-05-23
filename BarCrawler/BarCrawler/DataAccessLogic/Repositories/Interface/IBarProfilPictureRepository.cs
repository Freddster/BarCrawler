using BarCrawler.Models;
using BarCrawler.ViewModels;

namespace BarCrawler.DataAccessLogic.Repositories.Interface
{
    public interface IBarProfilPictureRepository : IRepository<BarProfilPictureModel>
    {
        void AddModelForUpdate(ref PictureViewModel viewModel, ref BarProfilPictureModel pictureModel, string imgDir);
    }
}