using System.Data.Entity.Core.Metadata.Edm;
using BarCrawler.Models;
using BarCrawler.ViewModels;

namespace BarCrawler.DataAccessLogic.Repositories.Interface
{
    public interface IPictureRepository : IRepository<PictureModel>
    {
        void AddModelForUpdate(ref PictureViewModel viewModel, ref PictureModel picturemodel);
        void AddModelForUpdate(ref PictureViewModel viewModel, ref PictureModel picturemodel, string imageDir);
    }
}