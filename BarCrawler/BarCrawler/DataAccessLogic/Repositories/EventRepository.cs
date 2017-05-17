using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarCrawler.Models;

namespace DataAccessLogic.Repositories
{
    /// <summary>
    /// The EventRepository contains the different functions to find all or a specific event
    /// <seealso cref="System.IDisposable" />
    public class EventRepository : IDisposable
    {
        
        private BarCrawlerContext _context;
        private DbSet<EventModel> _eventDbSet;

        /// <summary>
        /// This is the EventRepository's constructor, where the dbset for EventRepository are set. 
        /// The dbSet contains a table for all registred events in the project
        /// Initializes a new instance of the <see cref="EventRepository"/> class.
        /// </summary>
        /// <param name="receivedContext">The received context.</param>
        public EventRepository(BarCrawlerContext ReceivedContext)
        {
            _context = ReceivedContext;
            _eventDbSet = ReceivedContext.EventModels;
        }


        /// <summary>
        /// Gets all events in the dbSet for EventRepository.
        /// </summary>
        /// <param name="GetAllEvents">GetAllBars</param>
        /// <returns></returns>
        public IEnumerable<EventModel> GetAllEvents()
        {
            return _eventDbSet.ToList();
        }

        //Lav en funktion der kun returnere x antal events

        /// <summary>
        /// Gets a event by it's ID from the dbSet
        /// </summary>
        /// <param name="GetEventByID">GetBarByID</param>
        /// <returns></returns>
        public EventModel GetEventByID(int? id)
        {
            return _eventDbSet.Find(id);
        }


        /// <summary>
        /// Adds a new event to the dbSet of EventRepository.
        /// </summary>
        /// <param name="eventModel">Add a new event.</param>
        public void AddEvent(EventModel eventModel)
        {
            _eventDbSet.Add(eventModel);
        }

        /// <summary>
        /// Deletes a event from the dbSet if it exists
        /// </summary>
        /// <param name="DeleteBar">Deletes a event</param>
        public void DeleteEvent(int? eventModelID)
        {
            EventModel eventModel = _eventDbSet.Find((eventModelID));
            if (eventModel != null)
                _eventDbSet.Remove(eventModel);
        }

        /// <summary>
        /// Updates the event model.
        /// </summary>
        /// <param name="barModel">Updates a event</param>
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
