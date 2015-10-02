namespace Personalsystem.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Personalsystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Personalsystem.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Personalsystem.Models.ApplicationDbContext context)
        {
            var rolestore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(rolestore);

            if (!roleManager.RoleExists("admin"))
            {
                var role = new IdentityRole();
                role.Name = "admin";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("boss"))
            {
                var role = new IdentityRole();
                role.Name = "boss";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("employee"))
            {
                var role = new IdentityRole();
                role.Name = "employee";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("applicant"))
            {
                var role = new IdentityRole();
                role.Name = "applicant";
                roleManager.Create(role);
            }
            context.SaveChanges();

            context.Adresses.AddOrUpdate(
            new Adress { Id = 1, City = "Gävle", Street = "Drottninggatan", StreetNumber = "9", ZipCode = "803 00" }
                );
            context.SaveChanges();
            var User1 = new ApplicationUser { Email = "admin@adminsson.dk", UserName = "admin@adminsson.dk", Adress = context.Adresses.First(), PhoneNumber = "12345678" };
            var User2 = new ApplicationUser { Email = "user@usersson.dk", UserName = "user@usersson.dk", Adress = context.Adresses.First(), PhoneNumber = "23456789" };

            var userstore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userstore);

            userManager.Create(User1);
            userManager.Create(User2);

            userManager.AddPassword(context.Users.Single(u => u.Email == "admin@adminsson.dk").Id, "Password123!");
            userManager.AddPassword(context.Users.Single(u => u.Email == "user@usersson.dk").Id, "Password123!");

            userManager.AddToRole(context.Users.Single(u => u.Email == "admin@adminsson.dk").Id, "admin");
            userManager.AddToRole(context.Users.Single(u => u.Email == "user@usersson.dk").Id, "applicant");

            context.Companies.AddOrUpdate(
                new Models.Company { Id = 1, Name = "Horse & Country" }
                );

            context.Departments.AddOrUpdate(
                new Models.Department { Id = 1, Name = "Economy", CompanyId  = 1 }
                );
            context.Groups.AddOrUpdate(
                new Models.Group { Id = 1, Name = "Group 1", DepartmentId = 1 }
                );
        }
    }
}
