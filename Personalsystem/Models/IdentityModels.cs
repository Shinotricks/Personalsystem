﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Web;


namespace Personalsystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public int? CvId { get; set; }
        [ForeignKey("CvId")]
        public virtual CV CV { get; set; }

        public int? AdressId { get; set; }
        [ForeignKey("AdressId")]
        public virtual Adress Adress { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Job> JobsApplied { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<CV> CVs { get; set; }

        public DbSet<Adress> Adresses { get; set; }

        public System.Data.Entity.DbSet<Personalsystem.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<Personalsystem.Models.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<Personalsystem.Models.Group> Groups { get; set; }

        public System.Data.Entity.DbSet<Personalsystem.Models.Job> Jobs { get; set; }

        public System.Data.Entity.DbSet<Personalsystem.Models.ScheduleWeek> ScheduleWeeks { get; set; }

        public System.Data.Entity.DbSet<Personalsystem.Viewmodels.EditJobViewModel> EditJobViewModels { get; set; }

        public System.Data.Entity.DbSet<Personalsystem.Models.JobApplication> JobApplications { get; set; }
    }

    public class Adress
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string ZipCode { get; set; }
        public virtual ICollection<ApplicationUser> Tenants { get; set; }
    }

    public class CV
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
    }
}