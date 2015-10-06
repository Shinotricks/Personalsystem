namespace Personalsystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeyFix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ScheduleWeeks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Monday_Start = c.DateTime(nullable: false),
                        Monday_End = c.DateTime(nullable: false),
                        Tuesday_Start = c.DateTime(nullable: false),
                        Tuesday_End = c.DateTime(nullable: false),
                        Wednesday_Start = c.DateTime(nullable: false),
                        Wednesday_End = c.DateTime(nullable: false),
                        Thursday_Start = c.DateTime(nullable: false),
                        Thursday_End = c.DateTime(nullable: false),
                        Friday_Start = c.DateTime(nullable: false),
                        Friday_End = c.DateTime(nullable: false),
                        Saturday_Start = c.DateTime(nullable: false),
                        Saturday_End = c.DateTime(nullable: false),
                        Sunday_Start = c.DateTime(nullable: false),
                        Sunday_End = c.DateTime(nullable: false),
                        Group_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.Group_Id)
                .Index(t => t.Group_Id);
            
            AddColumn("dbo.Groups", "ScheduleId", c => c.Int());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScheduleWeeks", "Group_Id", "dbo.Groups");
            DropIndex("dbo.ScheduleWeeks", new[] { "Group_Id" });
            DropColumn("dbo.Groups", "ScheduleId");
            DropTable("dbo.ScheduleWeeks");
        }
    }
}
