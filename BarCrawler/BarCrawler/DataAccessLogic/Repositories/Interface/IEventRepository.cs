using BarCrawler.Models;
using BarCrawler.ViewModels;

namespace BarCrawler.DataAccessLogic.Repositories.Interface
{
    public interface IEventRepository : IRepository<EventModel>
    {
        void EditInfo(EventViewModel viewModel, EventModel model);
    }
}