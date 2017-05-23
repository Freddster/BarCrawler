using BarCrawler.Models;
using BarCrawler.ViewModels;

namespace BarCrawler.DataAccessLogic.Repositories.Interface
{
    /// <summary>
    /// Interface for the Drink repositoiry to implement.
    /// </summary>
    /// <seealso cref="BarCrawler.DataAccessLogic.Repositories.Interface.IRepository{BarCrawler.Models.DrinkModel}" />
    public interface IDrinkRepository : IRepository<DrinkModel>
    {
        /// <summary>
        /// Update the <see cref="DrinkModel"/> drink model based on the data in the <see cref="DrinkViewModel"/>, and add it to the context for update.
        /// </summary>
        /// <param name="viewModel">The view model to take data from.</param>
        /// <param name="drinkModel">The <see cref="DrinkModel"/> to insert data into, and add to the database.</param>
        /// <seealso cref="DrinkModel"/>
        void AddModelForUpdate(ref DrinkViewModel viewModel, ref DrinkModel drinkModel);
    }
}