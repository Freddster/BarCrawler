using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
