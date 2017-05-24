using BarCrawler.Migrations;

namespace BarCrawler.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    /// <summary>
    /// Custom DbContext to store DbSets for the different repositories
    /// </summary>
    /// <seealso cref="DbContext" />
    /// <seealso cref="ICustomBarContext" />
    public class BarCrawlerContext : DbContext, ICustomBarContext
    {
        // Your context has been configured to use a 'BarModels' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BarCrawler.Models.BarModels' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BarModels' 
        // connection string in the application configuration file.
        /// <summary>
        /// Initializes a new instance of the <see cref="BarCrawlerContext"/> class.
        /// </summary>
        public BarCrawlerContext()
            : base("name=BarCrawlerContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        /// <summary>
        /// Navigational property to the BarModel table in the database
        /// </summary>
        /// <value>
        /// The bar models.
        /// </value>
        public virtual DbSet<BarModel> BarModels { get; set; }

        /// <summary>
        /// Navigational property to the BarProfilePictureModel table in the database
        /// </summary>
        /// <value>
        /// The bar profile picture models.
        /// </value>
        public virtual DbSet<BarProfilePictureModel> BarProfilePictureModels { get; set; }

        /// <summary>
        /// Navigational property to the CoverPictureModel table in the database
        /// </summary>
        /// <value>
        /// The cover picture models.
        /// </value>
        public virtual DbSet<CoverPictureModel> CoverPictureModels { get; set; }

        /// <summary>
        /// Navigational property to the DrinkModel table in the database
        /// </summary>
        /// <value>
        /// The drink models.
        /// </value>
        public virtual DbSet<DrinkModel> DrinkModels { get; set; }

        /// <summary>
        /// Navigational property to the DrinkPictureModel table in the database
        /// </summary>
        /// <value>
        /// The drink picture models.
        /// </value>
        public virtual DbSet<DrinkPictureModel> DrinkPictureModels { get; set; }

        /// <summary>
        /// Navigational property to the EventModel table in the database
        /// </summary>
        /// <value>
        /// The event models.
        /// </value>
        public virtual DbSet<EventModel> EventModels { get; set; }

        /// <summary>
        /// Navigational property to the FeedModel table in the database
        /// </summary>
        /// <value>
        /// The feed models.
        /// </value>
        public virtual DbSet<FeedModel> FeedModels { get; set; }

        /// <summary>
        /// Navigational property to the PictureModel table in the database
        /// </summary>
        /// <value>
        /// The picture models.
        /// </value>
        public virtual DbSet<PictureModel> PictureModels { get; set; }

        /// <summary>
        /// Creates a new instance of a derived <see cref="T:System.Data.Entity.DbContext" /> type.
        /// </summary>
        /// <returns>
        /// An instance of TContext
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public DbContext Create()
        {
            throw new NotImplementedException();
        }
    }
}