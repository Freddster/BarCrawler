namespace BarCrawler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Name for BarProfilPicture was changed throughout the project
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class WeirdChanged : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            RenameTable(name: "dbo.BarProfilPictureModels", newName: "BarProfilePictureModels");
        }

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            RenameTable(name: "dbo.BarProfilePictureModels", newName: "BarProfilPictureModels");
        }
    }
}
