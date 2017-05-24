using BarCrawler.DataAccessLogic.Repositories.Interface;
using BarCrawler.Models;
using BarCrawler.ViewModels;

namespace BarCrawler.DataAccessLogic.Repositories
{
    /// <summary>
    /// The EventRepository contains functions to store, edit and get the correct events from the database.
    /// </summary>
    public class EventRepository : GenericRepository<EventModel>, IEventRepository
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="EventRepository"/> class.
        /// </summary>
        /// <param name="ReceivedContext">The received context.</param>
        public EventRepository(BarCrawlerContext ReceivedContext) : base(ReceivedContext)
        {     
        }

        /// <summary>
        /// Adds the eventModel for update. <br/>
        /// And after marks the eventModel as dirty to indicate a change in the eventModel.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <param name="eventModel">The event model.</param>
        public void EditInfo(EventViewModel viewModel, EventModel model)
        {
            model.Title = viewModel.Title;
            model.Description = viewModel.Description;
            model.DateAndTimeForEvent = viewModel.DateAndTimeForEvent;
            model.Address1 = viewModel.Address1;
            model.Address2 = viewModel.Address2;
            model.StreetNumber = viewModel.StreetNumber;
            model.City = viewModel.City;
            model.Zipcode = viewModel.Zipcode;
            MarkAsDirty(model);
        }
    }
}
