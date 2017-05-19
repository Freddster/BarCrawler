using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using BarCrawler.DataAccessLogic;
using BarCrawler.DataAccessLogic.Repositories;
using BarCrawler.DataAccessLogic.Repositories.Interface;
using BarCrawler.Migrations;
using BarCrawler.Models;
using DataAccessLogic.Repositories;

namespace DataAccessLogic.UnitOfWork
{
    /// <summary>
    /// sdffds
    /// </summary>
    /// <seealso cref="DataAccessLogic.UnitOfWork.IUnitOfWork" />
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The context
        /// </summary>
        private BarCrawlerContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        public UnitOfWork()
        {
            //Database.SetInitializer(new BarCrawlerContextInitializer<BarCrawlerContext>());
            _context = new BarCrawlerContext();
            InitializeRepositories();
            //_barRepository = new BarRepository(_context);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitOfWork(BarCrawlerContext context)
        {
            //Database.SetInitializer(new BarCrawlerContextInitializer<BarCrawlerContext>());
            _context = context;
            InitializeRepositories();
        }

        public UnitOfWork(BarRepository barRepo)
        {
            this.barRepo = barRepo;
        }

        /// <summary>
        /// Initializes the repositories.
        /// </summary>
        private void InitializeRepositories()
        {
            CoverPictureRepository = new CoverPictureRepository(_context);
            BarProfilPictureRepository = new BarProfilPictureRepository(_context);
            BarRepository = new BarRepository(_context);
            DrinkRepository = new DrinkRepository(_context);
            EventRepository = new EventRepository(_context);
            FeedRepository = new FeedRepository(_context);
            PictureRepository = new PictureRepository(_context);
        }

        public ICoverPictureRepository CoverPictureRepository { get; set; }
        public IBarProfilPictureRepository BarProfilPictureRepository { get; set; }
        public IBarRepository BarRepository { get; private set; }
        public IDrinkRepository DrinkRepository { get; private set; }
        public IEventRepository EventRepository { get; private set; }
        public IFeedRepository FeedRepository { get; private set; }
        public IPictureRepository PictureRepository { get; private set; }


        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        

        /// <summary>
        /// Gets the barprofile.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public BarModel GetBarprofile(int? id)
        {

            var modelToReturn = _context.BarModels
                .Include(d => d.Drinks)
                .Include(f => f.Feeds)
                .Include(p => p.Pictures)
                .Include(pp => pp.BarProfilPictureModel)
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
        private const int TimeToSubtract = -12;
        private BarRepository barRepo;

        /// <summary>
        /// Gets all bars for home.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BarModel> GetAllBarsForHome()
        {
            var allModels = _context.BarModels
                .Include(p => p.BarProfilPictureModel)
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
