namespace BarCrawler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OpdateretDrinksModelPris : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BarModels", "Zipcode", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.DrinkModels", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.EventModels", "Address1", c => c.String(nullable: false));
            AlterColumn("dbo.EventModels", "StreetNumber", c => c.String(nullable: false));
            AlterColumn("dbo.EventModels", "City", c => c.String(nullable: false));
            AlterColumn("dbo.EventModels", "Zipcode", c => c.String(nullable: false, maxLength: 4));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EventModels", "Zipcode", c => c.String());
            AlterColumn("dbo.EventModels", "City", c => c.String());
            AlterColumn("dbo.EventModels", "StreetNumber", c => c.String());
            AlterColumn("dbo.EventModels", "Address1", c => c.String());
            AlterColumn("dbo.DrinkModels", "Price", c => c.String(nullable: false));
            AlterColumn("dbo.BarModels", "Zipcode", c => c.String(nullable: false, maxLength: 5));
        }
    }
}
