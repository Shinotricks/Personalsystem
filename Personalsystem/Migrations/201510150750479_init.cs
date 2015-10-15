namespace Personalsystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        Street = c.String(),
                        StreetNumber = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AdressId = c.Int(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Adresses", t => t.AdressId)
                .Index(t => t.AdressId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        ScheduleId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
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
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.GroupApplicationUsers",
                c => new
                    {
                        Group_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Group_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Groups", t => t.Group_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Group_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Jobs", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Companies", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Jobs", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.GroupApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.GroupApplicationUsers", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.ScheduleWeeks", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.Groups", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "AdressId", "dbo.Adresses");
            DropIndex("dbo.GroupApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.GroupApplicationUsers", new[] { "Group_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Jobs", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Jobs", new[] { "CompanyId" });
            DropIndex("dbo.ScheduleWeeks", new[] { "Group_Id" });
            DropIndex("dbo.Groups", new[] { "DepartmentId" });
            DropIndex("dbo.Departments", new[] { "CompanyId" });
            DropIndex("dbo.Companies", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "AdressId" });
            DropTable("dbo.GroupApplicationUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Jobs");
            DropTable("dbo.ScheduleWeeks");
            DropTable("dbo.Groups");
            DropTable("dbo.Departments");
            DropTable("dbo.Companies");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Adresses");
        }
    }
}
