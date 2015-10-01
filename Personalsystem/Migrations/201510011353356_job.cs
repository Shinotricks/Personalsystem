namespace Personalsystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class job : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Published = c.DateTime(nullable: false),
                        Deadline = c.DateTime(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.CompanyId)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Jobs", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Jobs", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Jobs", new[] { "CompanyId" });
            DropTable("dbo.Jobs");
        }
    }
}
