namespace FPTSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTrainerTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name1", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Name1");
        }
    }
}
