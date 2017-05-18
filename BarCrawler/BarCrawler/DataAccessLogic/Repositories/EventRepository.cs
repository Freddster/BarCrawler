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
    public class EventRepository : GenericRepository<EventModel>, IEventRepository
    {
       
        public EventRepository(BarCrawlerContext ReceivedContext) : base(ReceivedContext)
        {     
        }

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
