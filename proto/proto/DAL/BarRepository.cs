using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using proto.Models;

namespace proto.DAL
{
    public class BarRepository : IDisposable
    {
        private BarCrawlerContext context;
        private DbSet<BarModel> dbSet;


        public BarRepository(BarCrawlerContext context)
        {
            this.context = context;
            this.dbSet = context.BarModels;
        }


        //Get
        public IEnumerable<BarModel> GetAllBars()
        {
            return dbSet.ToList();
        }

        public BarModel GetBarByID(int? id)
        {
            return dbSet.Find(id);
        }


        //Add
        public void AddBar(BarModel barModel)
        {
            dbSet.Add(barModel);
        }


        public void DeleteStudent(int barModelID)
        {
            BarModel barModel = dbSet.Find((barModelID));
            dbSet.Remove(barModel);
        }

        public void UpdateBarModel(BarModel barmodel)
        {
            context.Entry(barmodel).State = EntityState.Modified;
        }

        //Delete

        //Update

        public void Dispose()
        {
        }
    }
}