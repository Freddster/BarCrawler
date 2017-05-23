using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarCrawler.DataAccessLogic.Repositories;
using BarCrawler.DataAccessLogic.Repositories.Interface;
using BarCrawler.Models;
using BarCrawler.ViewModels;

namespace DataAccessLogic.Repositories
{
    public class PictureRepository : GenericRepository<PictureModel>, IPictureRepository
    {
        public PictureRepository(BarCrawlerContext ReceivedContext) : base(ReceivedContext)
        {
            
        }


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
