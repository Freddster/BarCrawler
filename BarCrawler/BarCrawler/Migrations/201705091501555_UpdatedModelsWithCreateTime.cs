namespace BarCrawler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// CreateTime added to models
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class UpdatedModelsWithCreateTime : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            AddColumn("dbo.EventModels", "CreateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.FeedModels", "CreateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.PictureModels", "CreateTime", c => c.DateTime(nullable: false));
        }

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            DropColumn("dbo.PictureModels", "CreateTime");
            DropColumn("dbo.FeedModels", "CreateTime");
            DropColumn("dbo.EventModels", "CreateTime");
        }
    }
}
