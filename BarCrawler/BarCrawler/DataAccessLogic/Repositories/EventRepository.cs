using BarCrawler.DataAccessLogic.Repositories.Interface;
using BarCrawler.Models;
using BarCrawler.ViewModels;

namespace BarCrawler.DataAccessLogic.Repositories
{
    /// <summary>
    /// The EventRepository contains functions to store, edit and get the correct events from the database.
    /// </summary>
    /// <seealso cref="BarCrawler.DataAccessLogic.Repositories.GenericRepository{BarCrawler.Models.EventModel}" />
    /// <seealso cref="BarCrawler.DataAccessLogic.Repositories.Interface.IEventRepository" />
    public class EventRepository : GenericRepository<EventModel>, IEventRepository
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="EventRepository" /> class.
        /// </summary>
        /// <param name="ReceivedContext">The received context.</param>
        /// <seealso cref="BarCrawlerContext"/>
        public EventRepository(BarCrawlerContext ReceivedContext) : base(ReceivedContext)
        {     
        }

        /// <summary>
        /// Updates the information in the <see cref="EventModel"/> and then marks the model as dirty, and ready for update
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <param name="model">The <see cref="EventModel"/> to update the information in</param>
        /// <seealso cref="EventModel" />
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
