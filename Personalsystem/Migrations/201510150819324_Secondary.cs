namespace Personalsystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Secondary : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Jobs", new[] { "CompanyId" });
            CreateTable(
                "dbo.JobCompanies",
                c => new
                    {
                        Job_Id = c.Int(nullable: false),
                        Company_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Job_Id, t.Company_Id })
                .ForeignKey("dbo.Jobs", t => t.Job_Id, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.Company_Id, cascadeDelete: true)
                .Index(t => t.Job_Id)
                .Index(t => t.Company_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobCompanies", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.JobCompanies", "Job_Id", "dbo.Jobs");
            DropIndex("dbo.JobCompanies", new[] { "Company_Id" });
            DropIndex("dbo.JobCompanies", new[] { "Job_Id" });
            DropTable("dbo.JobCompanies");
            CreateIndex("dbo.Jobs", "CompanyId");
            AddForeignKey("dbo.Jobs", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
        }
    }
}
