namespace BarCrawler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Open and close time added to models
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class OpenCloseTimeInBarModel : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            AddColumn("dbo.BarModels", "OpenTime", c => c.String(nullable: false, maxLength: 5));
            AddColumn("dbo.BarModels", "CloseTime", c => c.String(nullable: false, maxLength: 5));
        }

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            DropColumn("dbo.BarModels", "CloseTime");
            DropColumn("dbo.BarModels", "OpenTime");
        }
    }
}
