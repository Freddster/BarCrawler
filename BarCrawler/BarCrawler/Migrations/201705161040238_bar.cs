namespace BarCrawler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BarModels", "userID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BarModels", "userID");
        }
    }
}
