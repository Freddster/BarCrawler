namespace BarCrawler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Initial migration to the database
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class Initial : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            CreateTable(
                "dbo.BarModels",
                c => new
                    {
                        BarID = c.Int(nullable: false, identity: true),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        BarName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 1000),
                        Email = c.String(nullable: false),
                        Faculty = c.String(nullable: false),
                        PhoneNumber = c.String(maxLength: 8),
                        Address1 = c.String(nullable: false),
                        Address2 = c.String(),
                        StreetNumber = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Zipcode = c.String(nullable: false, maxLength: 5),
                        Longitude = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.BarID);
            
            CreateTable(
                "dbo.DrinkModels",
                c => new
                    {
                        DrinkID = c.Int(nullable: false, identity: true),
                        BarID = c.Int(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Title = c.String(nullable: false),
                        Description = c.String(maxLength: 500),
                        Price = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DrinkID)
                .ForeignKey("dbo.BarModels", t => t.BarID, cascadeDelete: true)
                .Index(t => t.BarID);
            
            CreateTable(
                "dbo.EventModels",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        BarID = c.Int(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Title = c.String(nullable: false),
                        Description = c.String(maxLength: 1000),
                        DateAndTimeForEvent = c.DateTime(nullable: false),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        StreetNumber = c.String(),
                        City = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.BarModels", t => t.BarID, cascadeDelete: true)
                .Index(t => t.BarID);
            
            CreateTable(
                "dbo.FeedModels",
                c => new
                    {
                        FeedID = c.Int(nullable: false, identity: true),
                        BarID = c.Int(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Text = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.FeedID)
                .ForeignKey("dbo.BarModels", t => t.BarID, cascadeDelete: true)
                .Index(t => t.BarID);
            
            CreateTable(
                "dbo.PictureModels",
                c => new
                    {
                        PictureID = c.Int(nullable: false, identity: true),
                        BarID = c.Int(nullable: false),
                        Directory = c.String(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Description = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.PictureID)
                .ForeignKey("dbo.BarModels", t => t.BarID, cascadeDelete: true)
                .Index(t => t.BarID);
            
        }

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            DropForeignKey("dbo.PictureModels", "BarID", "dbo.BarModels");
            DropForeignKey("dbo.FeedModels", "BarID", "dbo.BarModels");
            DropForeignKey("dbo.EventModels", "BarID", "dbo.BarModels");
            DropForeignKey("dbo.DrinkModels", "BarID", "dbo.BarModels");
            DropIndex("dbo.PictureModels", new[] { "BarID" });
            DropIndex("dbo.FeedModels", new[] { "BarID" });
            DropIndex("dbo.EventModels", new[] { "BarID" });
            DropIndex("dbo.DrinkModels", new[] { "BarID" });
            DropTable("dbo.PictureModels");
            DropTable("dbo.FeedModels");
            DropTable("dbo.EventModels");
            DropTable("dbo.DrinkModels");
            DropTable("dbo.BarModels");
        }
    }
}
