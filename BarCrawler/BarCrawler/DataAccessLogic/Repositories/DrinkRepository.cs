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
    public class DrinkRepository : GenericRepository<DrinkModel>, IDrinkRepository
    {
        public DrinkRepository(BarCrawlerContext ReceivedContext) : base(ReceivedContext)
        {
        }

        public BarCrawlerContext BarCrawlerContext
        {
            get { return _context as BarCrawlerContext; }
        }

        public void AddModelForUpdate(ref DrinkViewModel viewModel, ref DrinkModel drinkModel)
        {
            drinkModel.Description = viewModel.Description;
            drinkModel.Price = viewModel.Price;
            drinkModel.Title = viewModel.Title;
            MarkAsDirty(drinkModel);
        }
    }
}
