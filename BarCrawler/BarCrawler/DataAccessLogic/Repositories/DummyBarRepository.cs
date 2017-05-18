using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BarCrawler.DataAccessLogic.Repositories;
using BarCrawler.DataAccessLogic.Repositories.Interface;
using BarCrawler.Models;

namespace DataAccessLogic.Repositories
{
    public class DummyBarRepository : IBarRepository
    {
        private BarCrawlerContext _context;
        private List<BarModel> m_barModel = null;

        public DummyBarRepository(BarCrawlerContext receivedContext)
        {
            _context = receivedContext;
        }

        public DummyBarRepository(List<BarModel> barModel)
        {
            m_barModel = barModel;
        }
      
        public IEnumerable<BarModel> GetAllBars()
        {
            return m_barModel;
        }

        public BarModel GetBarByID(int? id) //int? is nullable. int is not
        {
            return m_barModel.SingleOrDefault(BarModel => BarModel.BarID == id);
        }

        public void AddBar(BarModel barModel)
        {
            m_barModel.Add(barModel);
        }

        public void DeleteBar(int? barModelID)
        {
            BarModel barModeltoDelete = m_barModel.Find((b => b.BarID == barModelID));
            if (barModeltoDelete != null)
                m_barModel.Remove(barModeltoDelete);
        }

        public void UpdateBarModel(BarModel barModel)
        {
            int id = barModel.BarID;
            BarModel barToUpdate = m_barModel.SingleOrDefault(b => b.BarID == id);
            DeleteBar(barModel.BarID);
            m_barModel.Add(barModel);
        }

        public BarModel GetProfile(int? id)
        {
            return (m_barModel.SingleOrDefault(x => x.BarID == id));
        }
    }
}
