namespace Personalsystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CVnew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CVs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "CvId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "CvId");
            AddForeignKey("dbo.AspNetUsers", "CvId", "dbo.CVs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "CvId", "dbo.CVs");
            DropIndex("dbo.AspNetUsers", new[] { "CvId" });
            DropColumn("dbo.AspNetUsers", "CvId");
            DropTable("dbo.CVs");
        }
    }
}
