using BarCrawler.Models;
using BarCrawler.ViewModels;

namespace BarCrawler.DataAccessLogic.Repositories.Interface
{
    public interface IDrinkRepository : IRepository<DrinkModel>
    {
        void AddModelForUpdate(ref DrinkViewModel viewModel, ref DrinkModel drinkModel);
    }
}