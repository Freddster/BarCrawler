using BarCrawler.DataAccessLogic.Repositories.Interface;
using BarCrawler.Models;
using BarCrawler.ViewModels;

namespace BarCrawler.DataAccessLogic.Repositories
{
    /// <summary>
    /// The DrinkRepository is making sure to update the correct tables in case of any changes
    /// </summary>
    public class DrinkRepository : GenericRepository<DrinkModel>, IDrinkRepository
    {
        public DrinkRepository(BarCrawlerContext ReceivedContext) : base(ReceivedContext)
        {
        }

        public BarCrawlerContext BarCrawlerContext
        {
            get { return _context as BarCrawlerContext; }
        }

        /// <summary>
        /// Adds the drinkModel for update. <br/>
        /// And after marks the drinkModel as dirty to indicate a change in the DrinkModel.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <param name="drinkModel">The drink model.</param>
        public void AddModelForUpdate(ref DrinkViewModel viewModel, ref DrinkModel drinkModel)
        {
            drinkModel.Description = viewModel.Description;
            drinkModel.Price = viewModel.Price;
            drinkModel.Title = viewModel.Title;
            MarkAsDirty(drinkModel);
        }
    }
}
