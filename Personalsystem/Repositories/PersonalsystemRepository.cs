using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Personalsystem.Models;
using Personalsystem.Viewmodels;

namespace Personalsystem.Repositories
{
    public class PersonalsystemRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public PersonalsystemRepository()
        {
            db = new ApplicationDbContext();
        }

        #region AccountStuff
        public IEnumerable<ApplicationUser> ApplicationUsers()
        {
            return db.Users.ToList();


        }
        public IEnumerable<UserViewModel> UserViewModels()
        {
            List<UserViewModel> viewModels = new List<UserViewModel>();
            foreach (ApplicationUser user in db.Users.ToList())
            {
                if (user.Adress != null)
                {
                    viewModels.Add(new UserViewModel
                        {
                            City = user.Adress.City,
                            Email = user.Email,
                            Number = user.PhoneNumber,
                            Street = user.Adress.Street,
                            StreetNumber = user.Adress.StreetNumber,
                            ZipCode = user.Adress.ZipCode
                        });
                }
                else
                {
                    viewModels.Add(new UserViewModel
                    {
                        Email = user.Email,
                        Number = user.PhoneNumber
                    });
                }
            }
            return viewModels;

        }
        #endregion

        #region Jobstuff
        public IEnumerable<Job> Jobs()
        {
            return db.Jobs.ToList();
        }

        public Job JobDetails(int? JobId)
        {
            return db.Jobs.Single(d => d.Id == JobId);
        }

        public Job CreateJob(Job job)
        {
            db.Jobs.Add(job);
            db.SaveChanges();
            return job;
        }

        #endregion

        #region Company Methods
        public IEnumerable<Company> Companies()
        {
            return db.Companies.ToList();
        }

        public Company GetSpecificCompany(int? companyId)
        {
            return db.Companies.Single(d => d.Id == companyId);
        }

        public Company CreateCompany(Company company)
        {
            db.Companies.Add(company);
            db.SaveChanges();

            return company;
        }

        public Company EditCompany(Company company)
        {
            db.Entry(company).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return company;
        }

        public Company RemoveCompany(Company company)
        {
            db.Companies.Remove(company);
            db.SaveChanges();

            return company;
        }
        #endregion

        #region Department Methods
        public IEnumerable<Department> Departments()
        {
            return db.Departments.ToList();
        }

        public IEnumerable<Department> GetDepartmentsByCompanyId(int? id)
        {
            return db.Departments.Where(i => i.CompanyId == id).ToList();
        }

        public Department GetSpecificDepartment(int? departmentId)
        {
            return db.Departments.Single(d => d.Id == departmentId);
        }

        public Department CreateDepartment(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();

            return department;
        }

        public Department EditDepartment(Department department)
        {
            db.Entry(department).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return department;
        }

        public Department RemoveDepartment(Department department)
        {
            db.Departments.Remove(department);
            db.SaveChanges();

            return department;
        }
        #endregion

        #region Group Methods
        public IEnumerable<Group> Groups()
        {
            return db.Groups.ToList();
        }
        public IEnumerable<Group> GetGroupsByDepartmentId(int? id)
        {
            return db.Groups.Where(i => i.DepartmentId == id).ToList();
        }

        public Group GetSpecificGroup(int? groupId)
        {
            return db.Groups.Single(d => d.Id == groupId);
        }

        public Group CreateGroup(Group group)
        {
            db.Groups.Add(group);
            db.SaveChanges();

            return group;
        }

        public void EditGroup(Group group)
        {
            db.Entry(group).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveGroup(Group group)
        {
            db.Groups.Remove(group);
            db.SaveChanges();
        }
        #endregion

        public void Dispose()
        {
            db.Dispose();
        }
    }
}