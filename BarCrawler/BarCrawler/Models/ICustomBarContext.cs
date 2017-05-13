using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace BarCrawler.Models
{
    public interface ICustomBarContext : IDbContextFactory<DbContext>
    {
        DbSet<BarModel> BarModels { get; set; }
        DbSet<DrinkModel> DrinkModels { get; set; }
        DbSet<EventModel> EventModels { get; set; }
        DbSet<FeedModel> FeedModels { get; set; }
        DbSet<PictureModel> PictureModels { get; set; }
        int SaveChanges();
    }
}