using BarCrawler.Models;
using BarCrawler.ViewModels;

namespace BarCrawler.DataAccessLogic.Repositories.Interface
{
    public class CoverPictureRepository : GenericRepository<CoverPictureModel>, ICoverPictureRepository
    {
        public CoverPictureRepository(BarCrawlerContext ReceivedContext) : base(ReceivedContext)
        {
        }

        public void AddModelForUpdate(ref PictureViewModel viewModel, ref CoverPictureModel pictureModel)
        {
            pictureModel.Directory = viewModel.Directory;
            pictureModel.Description = viewModel.Description;
            MarkAsDirty(pictureModel);
        }
    }
}