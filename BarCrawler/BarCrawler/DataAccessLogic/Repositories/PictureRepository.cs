using BarCrawler.DataAccessLogic.Repositories.Interface;
using BarCrawler.Models;
using BarCrawler.ViewModels;

namespace BarCrawler.DataAccessLogic.Repositories
{
    /// <summary>
    /// The PictureRepository is making sure to update the correct tables in case of any changes
    /// </summary>
    public class PictureRepository : GenericRepository<PictureModel>, IPictureRepository
    {
        public PictureRepository(BarCrawlerContext ReceivedContext) : base(ReceivedContext)
        {
            
        }

        /// <summary>
        /// Adds the pictureModel for update. <br/>
        /// And after marks the pictureModel as dirty to indicate a change in the pictureModel.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <param name="pictureModel">The picture model.</param>
        public void AddModelForUpdate(ref PictureViewModel viewModel, ref PictureModel pictureModel)
        {
            pictureModel.Directory = viewModel.Directory;
            pictureModel.Description = viewModel.Description;
            MarkAsDirty(pictureModel);
        }
    }
}
