namespace Personalsystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class company : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Companies", "OwnerId", "dbo.AspNetUsers");
            DropIndex("dbo.Companies", new[] { "OwnerId" });
            RenameColumn(table: "dbo.Companies", name: "OwnerId", newName: "ApplicationUser_Id");
            AlterColumn("dbo.Companies", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Companies", "ApplicationUser_Id");
            AddForeignKey("dbo.Companies", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Companies", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.Companies", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            RenameColumn(table: "dbo.Companies", name: "ApplicationUser_Id", newName: "OwnerId");
            CreateIndex("dbo.Companies", "OwnerId");
            AddForeignKey("dbo.Companies", "OwnerId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
