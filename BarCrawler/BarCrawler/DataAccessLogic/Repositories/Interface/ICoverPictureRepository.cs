using BarCrawler.Models;
using BarCrawler.ViewModels;

namespace BarCrawler.DataAccessLogic.Repositories.Interface
{
    /// <summary>
    /// Interface for the CoverPicture repositoiry to implement.
    /// </summary>
    /// <seealso cref="CoverPictureModel" />
    public interface ICoverPictureRepository : IRepository<CoverPictureModel>
    {
        /// <summary>
        /// Update the CoverPictureModel based on the data in the PictureViewModel, and add it to the context for update.
        /// </summary>
        /// <param name="viewModel">The <see cref="PictureViewModel"/> to take data from</param>
        /// <param name="pictureModel">The <see cref="CoverPictureModel"/> to insert data into, and add to the database.</param>
        /// <param name="imageDir">The image directory</param>
        /// <seealso cref="CoverPictureModel"/>
        void AddModelForUpdate(ref PictureViewModel viewModel, ref CoverPictureModel pictureModel, string imageDir);
    }
}