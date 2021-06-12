namespace FPTSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatesToModelProperites : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.AspNetUsers", "Name1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Name1", c => c.String());
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
        }
    }
}
