namespace proto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BarModels", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.BarModels", "Adresse", c => c.String(nullable: false));
            AlterColumn("dbo.BarModels", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BarModels", "Email", c => c.String());
            AlterColumn("dbo.BarModels", "Adresse", c => c.String());
            AlterColumn("dbo.BarModels", "Name", c => c.String());
        }
    }
}
