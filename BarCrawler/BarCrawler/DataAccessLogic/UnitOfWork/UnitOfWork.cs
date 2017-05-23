using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BarCrawler.DataAccessLogic.Repositories;
using BarCrawler.DataAccessLogic.Repositories.Interface;
using BarCrawler.Migrations;
using BarCrawler.Models;

namespace BarCrawler.DataAccessLogic.UnitOfWork
{
    /// <summary>
    /// Unit of work for storing the functions of the repositories, and have one place to access them all.
    /// </summary>
    /// <seealso cref="BarCrawler.DataAccessLogic.UnitOfWork.IUnitOfWork" />
    /// <seealso cref="IUnitOfWork" />
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The context
        /// </summary>
        private BarCrawlerContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        public UnitOfWork()
        {
            Database.SetInitializer(new BarCrawlerContextInitializer<BarCrawlerContext>());
            _context = new BarCrawlerContext();
            InitializeRepositories();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitOfWork(BarCrawlerContext context)
        {
            Database.SetInitializer(new BarCrawlerContextInitializer<BarCrawlerContext>());
            _context = context;
            InitializeRepositories();
        }

        /// <summary>
        /// Initializes the repositories.
        /// </summary>
        private void InitializeRepositories()
        {
            CoverPictureRepository = new CoverPictureRepository(_context);
            BarProfilePictureRepository = new BarProfilePictureRepository(_context);
            BarRepository = new BarRepository(_context);
            DrinkRepository = new DrinkRepository(_context);
            EventRepository = new EventRepository(_context);
            FeedRepository = new FeedRepository(_context);
            PictureRepository = new PictureRepository(_context);
        }

        /// <summary>
        /// Gets the cover picture repository.
        /// </summary>
        /// <value>
        /// The cover picture repository.
        /// </value>
        /// <seealso cref="ICoverPictureRepository" />
        public ICoverPictureRepository CoverPictureRepository { get; set; }

        /// <summary>
        /// Gets the bar profil picture repository.
        /// </summary>
        /// <value>
        /// The bar profil picture repository.
        /// </value>
        /// <seealso cref="IBarProfilePictureRepository" />
        public IBarProfilePictureRepository BarProfilePictureRepository { get; set; }
        
        /// <summary>
        /// Gets the bar repository.
        /// </summary>
        /// <value>
        /// The bar repository.
        /// </value>
        /// <seealso cref="IBarRepository" />
        public IBarRepository BarRepository { get; private set; }

        /// <summary>
        /// Gets the drink repository.
        /// </summary>
        /// <value>
        /// The drink repository.
        /// </value>
        /// <seealso cref="IDrinkRepository" />

        public IDrinkRepository DrinkRepository { get; private set; }
        /// <summary>
        /// Gets the event repository.
        /// </summary>
        /// <value>
        /// The event repository.
        /// </value>
        /// <seealso cref="IEventRepository" />
        public IEventRepository EventRepository { get; private set; }
        
        /// <summary>
        /// Gets the feed repository.
        /// </summary>
        /// <value>
        /// The feed repository.
        /// </value>
        /// <seealso cref="IFeedRepository" />
        public IFeedRepository FeedRepository { get; private set; }
        
        /// <summary>
        /// Gets the picture repository.
        /// </summary>
        /// <value>
        /// The picture repository.
        /// </value>
        /// <seealso cref="IPictureRepository" />
        public IPictureRepository PictureRepository { get; private set; }


        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }



        /// <summary>
        /// Gets the barprofile for the bar with the given id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Barmodel with associated drinks, events, feeds, profile picture, cover picture and picutes</returns>
        public BarModel GetBarprofile(int? id)
        {
            var modelToReturn = _context.BarModels
                .Include(d => d.Drinks)
                .Include(f => f.Feeds)
                .Include(p => p.Pictures)
                .Include(pp => pp.BarProfilePicture)
                .Include(ppp => ppp.CoverPicture)
                .SingleOrDefault(x => x.BarID == id);

            if (modelToReturn == null)
                return null;

            modelToReturn.Feeds = modelToReturn.Feeds.OrderByDescending(o => o.CreateTime).ToList();

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


        /// <summary>
        /// The time to subtract from events to search for in database
        /// </summary>
        private const int TimeToSubtract = -12;

        /// <summary>
        /// Gets all bars for home index with associated events, feeds and profile picture.
        /// </summary>
        /// <returns>
        /// All the Barmodels with associated events, feeds and profile picture in an unidentified collection.
        /// </returns>
        public IEnumerable<BarModel> GetAllBarsForHome()
        {
            var allModels = _context.BarModels
                .Include(p => p.BarProfilePicture)
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
