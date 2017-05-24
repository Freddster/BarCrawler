using BarCrawler.Models;
using BarCrawler.ViewModels;

namespace BarCrawler.DataAccessLogic.Repositories.Interface
{
    /// <summary>
    /// Interface for the Event repositoiry to implement.
    /// </summary>
    /// <seealso cref="EventModel" />
    public interface IEventRepository : IRepository<EventModel>
    {
        /// <summary>
        /// Edits the information for an event.
        /// </summary>
        /// <param name="viewModel">The view model to take data from</param>
        /// <param name="model">The <see cref="EventModel" /> to update the information in</param>
        /// <seealso cref="EventModel" />
        void EditInfo(EventViewModel viewModel, EventModel model);
    }
}