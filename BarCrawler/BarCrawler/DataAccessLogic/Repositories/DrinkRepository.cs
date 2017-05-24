using BarCrawler.DataAccessLogic.Repositories.Interface;
using BarCrawler.Models;
using BarCrawler.ViewModels;

namespace BarCrawler.DataAccessLogic.Repositories
{
    /// <summary>
    /// The DrinkRepository contains functions to store, edit and get the correct drinks from the database.
    /// </summary>
    public class DrinkRepository : GenericRepository<DrinkModel>, IDrinkRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DrinkRepository"/> class.
        /// </summary>
        /// <param name="ReceivedContext">The received context.</param>
        public DrinkRepository(BarCrawlerContext ReceivedContext) : base(ReceivedContext)
        {
        }

        /// <summary>
        /// Gets the bar crawler context.
        /// </summary>
        /// <value>
        /// The bar crawler context.
        /// </value>
        public BarCrawlerContext BarCrawlerContext
        {
            get { return _context as BarCrawlerContext; }
        }

        /// <summary>
        /// Adds the drinkModel for update. <br />
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
