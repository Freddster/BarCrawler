using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BarCrawler.DataAccessLogic.Repositories.Interface;
using BarCrawler.Models;
using BarCrawler.ViewModels;

namespace BarCrawler.DataAccessLogic.Repositories
{
    /// <summary>
    /// The BarProfilePictureRepository contains functions to store, edit and get the correct bar profile pictures from the database.
    /// </summary>
    public class BarProfilePictureRepository : GenericRepository<BarProfilePictureModel>, IBarProfilePictureRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BarProfilePictureRepository" /> class.
        /// </summary>
        /// <param name="context"></param>
        public BarProfilePictureRepository(BarCrawlerContext context) : base(context)
        {
        }

        /// <summary>
        /// Updates the Directory and Description for the model before marking it as dirty.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <param name="pictureModel">The picture model.</param>
        public void AddModelForUpdate(ref PictureViewModel viewModel, ref BarProfilePictureModel pictureModel, string imgDir)
        {
            pictureModel.Directory = imgDir;
            pictureModel.Description = viewModel.Description;
            MarkAsDirty(pictureModel);
        }
    }
}