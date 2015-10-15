namespace Personalsystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Secondary2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobCompanies", "Job_Id", "dbo.Jobs");
            DropForeignKey("dbo.JobCompanies", "Company_Id", "dbo.Companies");
            DropIndex("dbo.JobCompanies", new[] { "Job_Id" });
            DropIndex("dbo.JobCompanies", new[] { "Company_Id" });
            CreateIndex("dbo.Jobs", "CompanyId");
            AddForeignKey("dbo.Jobs", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
            DropTable("dbo.JobCompanies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.JobCompanies",
                c => new
                    {
                        Job_Id = c.Int(nullable: false),
                        Company_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Job_Id, t.Company_Id });
            
            DropForeignKey("dbo.Jobs", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Jobs", new[] { "CompanyId" });
            CreateIndex("dbo.JobCompanies", "Company_Id");
            CreateIndex("dbo.JobCompanies", "Job_Id");
            AddForeignKey("dbo.JobCompanies", "Company_Id", "dbo.Companies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.JobCompanies", "Job_Id", "dbo.Jobs", "Id", cascadeDelete: true);
        }
    }
}
