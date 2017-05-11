namespace BarCrawler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OpenCloseTimeInBarModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BarModels", "OpenTime", c => c.String(nullable: false, maxLength: 5));
            AddColumn("dbo.BarModels", "CloseTime", c => c.String(nullable: false, maxLength: 5));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BarModels", "CloseTime");
            DropColumn("dbo.BarModels", "OpenTime");
        }
    }
}
