namespace Personalsystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableint : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "AdressId", "dbo.Adresses");
            DropIndex("dbo.AspNetUsers", new[] { "AdressId" });
            AlterColumn("dbo.AspNetUsers", "AdressId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "AdressId");
            AddForeignKey("dbo.AspNetUsers", "AdressId", "dbo.Adresses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "AdressId", "dbo.Adresses");
            DropIndex("dbo.AspNetUsers", new[] { "AdressId" });
            AlterColumn("dbo.AspNetUsers", "AdressId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "AdressId");
            AddForeignKey("dbo.AspNetUsers", "AdressId", "dbo.Adresses", "Id", cascadeDelete: true);
        }
    }
}
