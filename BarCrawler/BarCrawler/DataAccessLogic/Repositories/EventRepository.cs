using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarCrawler.Models;

namespace DataAccessLogic.Repositories
{
    public class EventRepository : IDisposable
    {
        private BarCrawlerContext _context;
        private DbSet<EventModel> _eventDbSet;

        public EventRepository(BarCrawlerContext ReceivedContext)
        {
            _context = ReceivedContext;
            _eventDbSet = ReceivedContext.EventModels;
        }


        public IEnumerable<EventModel> GetAllEvents()
        {
            return _eventDbSet.ToList();
        }

        //Lav en funktion der kun returnere x antal events

        public EventModel GetEventByID(int? id)
        {
            return _eventDbSet.Find(id);
        }


        //Add
        public void AddEvent(EventModel eventModel)
        {
            _eventDbSet.Add(eventModel);
        }


        public void DeleteEvent(int? eventModelID)
        {
            EventModel eventModel = _eventDbSet.Find((eventModelID));
            if (eventModel != null)
                _eventDbSet.Remove(eventModel);
        }

        public void UpdateEventModel(EventModel eventModel)
        {
            _context.Entry(eventModel).State = EntityState.Modified;
        }



        public void Dispose()
        {
            _context?.Dispose();
        }

        //Find

        //Add

        //Delete

        //Remove
    }
}
