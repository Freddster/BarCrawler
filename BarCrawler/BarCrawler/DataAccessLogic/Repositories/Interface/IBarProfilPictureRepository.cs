using BarCrawler.Models;
using BarCrawler.ViewModels;

namespace BarCrawler.DataAccessLogic.Repositories.Interface
{
    public interface IBarProfilePictureRepository : IRepository<BarProfilePictureModel>
    {
        void AddModelForUpdate(ref PictureViewModel viewModel, ref BarProfilePictureModel pictureModel, string imgDir);
    }
}