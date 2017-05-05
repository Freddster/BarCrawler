namespace BarCrawler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDateTimeInFeedModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FeedModels", "DateAndTimeForFeed", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FeedModels", "DateAndTimeForFeed");
        }
    }
}
