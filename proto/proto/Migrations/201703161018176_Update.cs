namespace proto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BarModels", "Adresse", c => c.String());
            AddColumn("dbo.BarModels", "TelefonNr", c => c.String());
            AddColumn("dbo.BarModels", "Email", c => c.String());
            AddColumn("dbo.BarModels", "Fakultet", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BarModels", "Fakultet");
            DropColumn("dbo.BarModels", "Email");
            DropColumn("dbo.BarModels", "TelefonNr");
            DropColumn("dbo.BarModels", "Adresse");
        }
    }
}
