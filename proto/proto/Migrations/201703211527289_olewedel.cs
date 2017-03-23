namespace proto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class olewedel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "BarId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "BarId");
        }
    }
}
