using proto.Models;

namespace proto.DAL
{
    public class UnitOfWork
    {
        private BarCrawlerContext context = new BarCrawlerContext();
        private BarRepository barRepository;


        public BarRepository BarRepository
        {
            get
            {
                return barRepository ?? new BarRepository(context);

                /*if(this.BarRepository == null)
                    barRepository = new BarRepository(context);
                return barRepository;*/
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}