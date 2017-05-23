using BarCrawler.DataAccessLogic.Repositories.Interface;
using BarCrawler.Models;
using BarCrawler.ViewModels;

namespace BarCrawler.DataAccessLogic.Repositories
{
    /// <summary>
    /// The PictureRepository contains functions to store, edit and get the correct pictures from the database.
    /// </summary>
    /// <seealso cref="BarCrawler.DataAccessLogic.Repositories.GenericRepository{BarCrawler.Models.PictureModel}" />
    /// <seealso cref="BarCrawler.DataAccessLogic.Repositories.Interface.IPictureRepository" />
    public class PictureRepository : GenericRepository<PictureModel>, IPictureRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PictureRepository"/> class.
        /// </summary>
        /// <param name="ReceivedContext">The received context.</param>
        public PictureRepository(BarCrawlerContext ReceivedContext) : base(ReceivedContext)
        {
        }

        /// <summary>
        /// Adds the pictureModel for update. <br />
        /// And after marks the pictureModel as dirty to indicate a change in the pictureModel.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <param name="pictureModel">The picture model.</param>
        public void AddModelForUpdate(ref PictureViewModel viewModel, ref PictureModel pictureModel, string imageDir)
        {
            pictureModel.Directory = imageDir;
            pictureModel.Description = viewModel.Description;
            MarkAsDirty(pictureModel);
        }

        public void AddModelForUpdate(ref PictureViewModel viewModel, ref PictureModel picturemodel)
        {
            picturemodel.Description = viewModel.Description;
            MarkAsDirty(picturemodel);
        }
    }
}
