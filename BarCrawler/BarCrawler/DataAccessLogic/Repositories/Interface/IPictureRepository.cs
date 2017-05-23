using System.Data.Entity.Core.Metadata.Edm;
using BarCrawler.Models;
using BarCrawler.ViewModels;

namespace BarCrawler.DataAccessLogic.Repositories.Interface
{
    /// <summary>
    /// Interface for the Picture repositoiry to implement.
    /// </summary>
    /// <seealso cref="BarCrawler.DataAccessLogic.Repositories.Interface.IRepository{BarCrawler.Models.PictureModel}" />
    public interface IPictureRepository : IRepository<PictureModel>
    {
        /// <summary>
        /// Update the picture model based on the data in the picture view model, and add it to the context for update.
        /// </summary>
        /// <param name="viewModel">The view model to take data from.</param>
        /// <param name="picturemodel">The <see cref="PictureModel" /> to insert data into, and add to the database.</param>
        /// <seealso cref="PictureModel"/>
        void AddModelForUpdate(ref PictureViewModel viewModel, ref PictureModel picturemodel);

        /// <summary>
        /// Update the picture model based on the data in the picture view model, and add it to the context for update.
        /// </summary>
        /// <param name="viewModel">The view model to take data from</param>
        /// <param name="picturemodel">The <see cref="PictureModel"/> to insert data into, and add to the database.</param>
        /// <param name="imageDir">The image directory</param>
        /// <seealso cref="PictureModel"/>
        void AddModelForUpdate(ref PictureViewModel viewModel, ref PictureModel picturemodel, string imageDir);
    }
}