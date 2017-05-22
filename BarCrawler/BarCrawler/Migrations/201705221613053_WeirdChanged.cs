namespace BarCrawler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WeirdChanged : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BarProfilPictureModels", newName: "BarProfilePictureModels");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.BarProfilePictureModels", newName: "BarProfilPictureModels");
        }
    }
}
