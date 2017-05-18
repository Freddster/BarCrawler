using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarCrawler.DataAccessLogic.Repositories;
using BarCrawler.DataAccessLogic.Repositories.Interface;
using BarCrawler.Models;

namespace DataAccessLogic.Repositories
{
    public class EventRepository : GenericRepository<EventModel>, IEventRepository
    {
       
        public EventRepository(BarCrawlerContext ReceivedContext) : base(ReceivedContext)
        {     
        }
    }
}
