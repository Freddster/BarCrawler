namespace BarCrawler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCoverPictureModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CoverPictureModels",
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
            DropForeignKey("dbo.CoverPictureModels", "BarID", "dbo.BarModels");
            DropIndex("dbo.CoverPictureModels", new[] { "BarID" });
            DropTable("dbo.CoverPictureModels");
        }
    }
}
