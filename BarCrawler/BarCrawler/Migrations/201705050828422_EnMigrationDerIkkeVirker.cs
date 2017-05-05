namespace BarCrawler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnMigrationDerIkkeVirker : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BarModels", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BarModels", "UserId", c => c.String());
        }
    }
}
