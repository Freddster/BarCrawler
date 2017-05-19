using BarCrawler.Models;
using BarCrawler.ViewModels;

namespace BarCrawler.DataAccessLogic.Repositories.Interface
{
    public interface ICoverPictureRepository : IRepository<CoverPictureModel>
    {
        void AddModelForUpdate(ref PictureViewModel viewModel, ref CoverPictureModel pictureModel);
    }
}