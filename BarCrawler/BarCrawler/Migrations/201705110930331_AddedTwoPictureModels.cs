namespace BarCrawler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTwoPictureModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DrinkPictureModels",
                c => new
                    {
                        DrinkPictureID = c.Int(nullable: false, identity: true),
                        DrinkID = c.Int(nullable: false),
                        Directory = c.String(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.DrinkPictureID)
                .ForeignKey("dbo.DrinkModels", t => t.DrinkID, cascadeDelete: true)
                .Index(t => t.DrinkID);
            
            CreateTable(
                "dbo.BarProfilPictureModels",
                c => new
                    {
                        BarID = c.Int(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        CreateTime = c.DateTime(nullable: false),
                        Directory = c.String(),
                        Description = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.BarID)
                .ForeignKey("dbo.BarModels", t => t.BarID)
                .Index(t => t.BarID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BarProfilPictureModels", "BarID", "dbo.BarModels");
            DropForeignKey("dbo.DrinkPictureModels", "DrinkID", "dbo.DrinkModels");
            DropIndex("dbo.BarProfilPictureModels", new[] { "BarID" });
            DropIndex("dbo.DrinkPictureModels", new[] { "DrinkID" });
            DropTable("dbo.BarProfilPictureModels");
            DropTable("dbo.DrinkPictureModels");
        }
    }
}
