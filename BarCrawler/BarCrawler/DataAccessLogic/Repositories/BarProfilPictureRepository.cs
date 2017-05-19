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
    public class BarProfilPictureRepository : GenericRepository<BarProfilPictureModel>, IBarProfilPictureRepository
    {
        public BarProfilPictureRepository(DbContext context) : base(context)
        {
        }

        public void AddModelForUpdate(ref PictureViewModel viewModel, ref BarProfilPictureModel pictureModel)
        {
            pictureModel.Directory = viewModel.Directory;
            pictureModel.Description = viewModel.Description;
            MarkAsDirty(pictureModel);
        }
    }
}