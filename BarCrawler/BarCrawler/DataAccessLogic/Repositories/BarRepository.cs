using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BarCrawler.Models;

namespace DataAccessLogic.Repositories
{
    public class BarRepository : IDisposable
    {
        private BarCrawlerContext _context;
        private DbSet<BarModel> _dbSet;

        public BarRepository(BarCrawlerContext receivedContext)
        {
            _context = receivedContext;
            _dbSet = receivedContext.BarModels;
        }


        public IEnumerable<BarModel> GetAllBars()
        {
            return _dbSet.ToList();
        }

        public BarModel GetBarByID(int? id) //int? is nullable. int is not
        {
            return _dbSet.Find(id);
        }

        public BarModel GetProfile(int? id)
        {
            return (_dbSet.Include(d => d.Drinks)
                .Include(e => e.Events)
                .Include(f => f.Feeds)
                .Include(p => p.Pictures)
                .SingleOrDefault(x => x.BarID == id));
        }


        //Add
        public void AddBar(BarModel barModel)
        {
            _dbSet.Add(barModel);
        }

        //Delete
        public void DeleteBar(int? barModelID)
        {
            BarModel barModel = _dbSet.Find((barModelID));
            if (barModel != null)
                _dbSet.Remove(barModel);
        }

        //Update
        public void UpdateBarModel(BarModel barmodel)
        {
            _context.Entry(barmodel).State = EntityState.Modified;
        }


        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
