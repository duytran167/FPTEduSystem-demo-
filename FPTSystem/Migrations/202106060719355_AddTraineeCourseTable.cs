namespace FPTSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTraineeCourseTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TraineeCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        TraineeID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.TraineeID)
                .Index(t => t.CourseID)
                .Index(t => t.TraineeID);
            
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int());
            AddColumn("dbo.AspNetUsers", "DateofBirth", c => c.String());
            AddColumn("dbo.AspNetUsers", "Education", c => c.String());
            AddColumn("dbo.AspNetUsers", "MainProgrammingLang", c => c.String());
            AddColumn("dbo.AspNetUsers", "ToeicScore", c => c.Single());
            AddColumn("dbo.AspNetUsers", "ExpDetail", c => c.String());
            AddColumn("dbo.AspNetUsers", "Department", c => c.String());
            AddColumn("dbo.AspNetUsers", "Location", c => c.String());
            AddColumn("dbo.AspNetUsers", "Education1", c => c.String());
            AddColumn("dbo.AspNetUsers", "WorkPlace", c => c.String());
            AddColumn("dbo.AspNetUsers", "Telephone", c => c.String());
            AddColumn("dbo.AspNetUsers", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TraineeCourses", "TraineeID", "dbo.AspNetUsers");
            DropForeignKey("dbo.TraineeCourses", "CourseID", "dbo.Courses");
            DropIndex("dbo.TraineeCourses", new[] { "TraineeID" });
            DropIndex("dbo.TraineeCourses", new[] { "CourseID" });
            DropColumn("dbo.AspNetUsers", "Type");
            DropColumn("dbo.AspNetUsers", "Telephone");
            DropColumn("dbo.AspNetUsers", "WorkPlace");
            DropColumn("dbo.AspNetUsers", "Education1");
            DropColumn("dbo.AspNetUsers", "Location");
            DropColumn("dbo.AspNetUsers", "Department");
            DropColumn("dbo.AspNetUsers", "ExpDetail");
            DropColumn("dbo.AspNetUsers", "ToeicScore");
            DropColumn("dbo.AspNetUsers", "MainProgrammingLang");
            DropColumn("dbo.AspNetUsers", "Education");
            DropColumn("dbo.AspNetUsers", "DateofBirth");
            DropColumn("dbo.AspNetUsers", "Age");
            DropTable("dbo.TraineeCourses");
        }
    }
}
