using BarCrawler.Models;
using BarCrawler.ViewModels;

namespace BarCrawler.DataAccessLogic.Repositories.Interface
{
    /// <summary>
    /// Interface for the bar profile picture repositoiry
    /// </summary>
    /// <seealso cref="BarCrawler.DataAccessLogic.Repositories.Interface.IRepository{BarCrawler.Models.BarProfilePictureModel}" />
    public interface IBarProfilePictureRepository : IRepository<BarProfilePictureModel>
    {
        /// <summary>
        /// Update the <see cref="BarProfilePictureModel"/> based on the data in the <see cref="PictureViewModel"/>, and add it to the context for update.
        /// </summary>
        /// <param name="viewModel">The view model to take data from</param>
        /// <param name="pictureModel">The <see cref="BarProfilePictureModel"/> to insert data into, and add to the database.</param>
        /// <param name="imgDir">The image directory</param>
        /// <seealso cref="PictureModel"/>
        void AddModelForUpdate(ref PictureViewModel viewModel, ref BarProfilePictureModel pictureModel, string imgDir);
    }
}