using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using BarCrawler.DataAccessLogic.Repositories.Interface;
using BarCrawler.Migrations;
using BarCrawler.Models;
using DataAccessLogic.Repositories;

namespace DataAccessLogic.UnitOfWork
{
    /// <summary>
    /// UnitOfWork class implementing IUnitOfWork. 
    /// </summary>
    /// <seealso cref="DataAccessLogic.UnitOfWork.IUnitOfWork" />
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The DbContext
        /// </summary>
        private BarCrawlerContext _context;// = new BarCrawlerContext();
        /// <summary>
        /// The bar repository
        /// </summary>
        private BarRepository _barRepository;
        /// <summary>
        /// The drink repository
        /// </summary>
        private DrinkRepository _drinkRepository;
        /// <summary>
        /// The event repository
        /// </summary>
        private EventRepository _eventRepository;
        /// <summary>
        /// The feed repository
        /// </summary>
        private FeedRepository _feedRepository;
        /// <summary>
        /// The picture repository
        /// </summary>
        private PictureRepository _pictureRepository;
        //private IDrinkRepository DrinkRepositoryyyyy;

        /// <summary>
        /// Gets the bar repository.
        /// </summary>
        /// <value>
        /// The bar repository.
        /// </value>
        public BarRepository BarRepository => _barRepository ?? new BarRepository(_context);
        //public DrinkRepository DrinkRepository => _drinkRepository ?? new DrinkRepository(_context);
        /// <summary>
        /// Gets the event repository.
        /// </summary>
        /// <value>
        /// The event repository.
        /// </value>
        public EventRepository EventRepository => _eventRepository ?? new EventRepository(_context);
        /// <summary>
        /// Gets the feed repository.
        /// </summary>
        /// <value>
        /// The feed repository.
        /// </value>
        public FeedRepository FeedRepository => _feedRepository ?? new FeedRepository(_context);
        /// <summary>
        /// Gets the picture repository.
        /// </summary>
        /// <value>
        /// The picture repository.
        /// </value>
        public PictureRepository PictureRepository => _pictureRepository ?? new PictureRepository(_context);
        //public DrinkRepository UgabugaDrinkRepository => DrinkRepositoryyyyy ?? new DrinkRepository(_context);

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        public UnitOfWork()
        {
            Database.SetInitializer(new BarCrawlerContextInitializer<BarCrawlerContext>());
            _context = new BarCrawlerContext();
            InitializeRepositories();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitOfWork(BarCrawlerContext context)
        {
            _context = context;
            InitializeRepositories();
        }

        /// <summary>
        /// Initializes the repositories.
        /// </summary>
        private void InitializeRepositories()
        {
            DrinkRepository = new DrinkRepository(_context);
        }

        public IDrinkRepository DrinkRepository { get; private set; }


        /// <summary>
        /// Saves the context.
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets the barprofile with all the drinks, feeds, pictures, profilPicture and comming events.
        /// </summary>
        /// <param name="id">The bar identifier.</param>
        /// <returns></returns>
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
                modelToReturn.Drinks = modelToReturn.Drinks.OrderBy(o => o.Title).ToList();
                
                //DateTime nowDateTime = new DateTime(2017, 05, 04, 16, 00, 00).AddHours(TimeToSubtract);
                DateTime nowDateTime = DateTime.Now.AddHours(TimeToSubtract);

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

        /// <summary>
        /// Gets all the bars for the frontpage, with profilePicture, feeds and comming events.
        /// </summary>
        /// <returns>Generic container</returns>
        public IEnumerable<BarModel> GetAllBarsForHome()
        {
            var allModels = _context.BarModels
                .Include(p => p.ProfilPictureModel)
                .Include(f => f.Feeds)
                .OrderBy(model => model.BarName)
                .ToList();

            List<BarModel> listToReturn = new List<BarModel>();

            //DateTime nowDateTime = new DateTime(2017, 05, 04, 16, 00, 00).AddHours(TimeToSubtract);
            DateTime nowDateTime = DateTime.Now.AddHours(TimeToSubtract);

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

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
