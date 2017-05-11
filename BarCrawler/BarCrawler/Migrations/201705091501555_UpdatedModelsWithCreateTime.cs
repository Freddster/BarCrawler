namespace BarCrawler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModelsWithCreateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventModels", "CreateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.FeedModels", "CreateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.PictureModels", "CreateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PictureModels", "CreateTime");
            DropColumn("dbo.FeedModels", "CreateTime");
            DropColumn("dbo.EventModels", "CreateTime");
        }
    }
}
