using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace BarCrawler.Models
{
    /// <summary>
    /// An interface which contains all the tables for all the models.
    /// </summary>
    /// <seealso cref="System.Data.Entity.Infrastructure.IDbContextFactory{System.Data.Entity.DbContext}" />
    public interface ICustomBarContext : IDbContextFactory<DbContext>
    {
        /// <summary>
        /// Gets or sets the bar models.
        /// </summary>
        /// <value>
        /// The bar models.
        /// </value>
        DbSet<BarModel> BarModels { get; set; }
        
        /// <summary>
        /// Gets or sets the drink models.
        /// </summary>
        /// <value>
        /// The drink models.
        /// </value>
        DbSet<DrinkModel> DrinkModels { get; set; }
        
        /// <summary>
        /// Gets or sets the event models.
        /// </summary>
        /// <value>
        /// The event models.
        /// </value>
        DbSet<EventModel> EventModels { get; set; }
        
        /// <summary>
        /// Gets or sets the feed models.
        /// </summary>
        /// <value>
        /// The feed models.
        /// </value>
        DbSet<FeedModel> FeedModels { get; set; }
        
        /// <summary>
        /// Gets or sets the picture models.
        /// </summary>
        /// <value>
        /// The picture models.
        /// </value>
        DbSet<PictureModel> PictureModels { get; set; }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns>Returns the error code</returns>
        int SaveChanges();
    }
}