using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using BarCrawler.Models;
using DataAccessLogic.Repositories;

namespace DataAccessLogic.UnitOfWork
{
    public class UnitOfWork
    {
        private BarCrawlerContext _context = new BarCrawlerContext();
        private BarRepository _barRepository;
        private DrinkRepository _drinkRepository;
        private EventRepository _eventRepository;
        private FeedRepository _feedRepository;
        private PictureRepository _pictureRepository;

        public BarRepository BarRepository => _barRepository ?? new BarRepository(_context);
        public DrinkRepository DrinkRepository => _drinkRepository ?? new DrinkRepository(_context);
        public EventRepository EventRepository => _eventRepository ?? new EventRepository(_context);
        public FeedRepository FeedRepository => _feedRepository ?? new FeedRepository(_context);
        public PictureRepository PictureRepository => _pictureRepository ?? new PictureRepository(_context);



        public void Save()
        {
            _context.SaveChanges();
        }

        public BarModel GetBarprofile(int? id)
        {
            var modelToReturn = _context.BarModels
                .Include(d => d.Drinks)
                .Include(f => f.Feeds)
                .Include(p => p.Pictures)
                .Include(pp => pp.ProfilPictureModel)
                .SingleOrDefault(x => x.BarID == id);

            if (modelToReturn != null)
            {
                DateTime nowDateTime = new DateTime(2017, 05, 04, 16, 00, 00).AddHours(TimeToSubtract);
            //DateTime nowDateTime = DateTime.Now.AddHours(TimeToSubtract);

            _context.Entry(modelToReturn)
                .Collection(e => e.Events)
                .Query()
                .Where(w => w.DateAndTimeForEvent > nowDateTime)
                .OrderBy(o => o.DateAndTimeForEvent)
                .Load();
            }
            
            return modelToReturn;
        }
        private const int TimeToSubtract = -12;

        public IEnumerable<BarModel> GetAllBarsForHome()
        {
            var allModels = _context.BarModels
                .Include(p => p.ProfilPictureModel)
                .Include(f => f.Feeds)
                .ToList();

            List<BarModel> listToReturn = new List<BarModel>();

            DateTime nowDateTime = new DateTime(2017, 05, 04, 16, 00, 00).AddHours(TimeToSubtract);
            //DateTimenowDateTime = DateTime.Now.AddHours(TimeToSubtract);

            foreach (var model in allModels)
            {
                _context.Entry(model)
                    .Collection(e => e.Events)
                    .Query()
                    .Where(w => w.DateAndTimeForEvent > nowDateTime)
                    .Load();
                listToReturn.Add(model);
            }

            return listToReturn;
        }
    }
}
