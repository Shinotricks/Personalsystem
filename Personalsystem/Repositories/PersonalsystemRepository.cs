﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Personalsystem.Models;
using Personalsystem.Viewmodels;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.AspNet.Identity;
using Personalsystem.Controllers;

namespace Personalsystem.Repositories
{
    public class PersonalsystemRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public PersonalsystemRepository()
        {
            db = new ApplicationDbContext();
        }

        public void AddUserRole(string id, string role)
        {
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(db);
            Microsoft.AspNet.Identity.UserManager<ApplicationUser> userManager = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>(userStore);

            userManager.AddToRole(id, role);

            db.SaveChanges();
            //return userManager;
        }

        public void RemoveUserRole(string id, string role)
        {
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(db);
            Microsoft.AspNet.Identity.UserManager<ApplicationUser> userManager = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>(userStore);
            //var oldRole = System.Web.Security.Roles.GetRolesForUser().Single();
            //var account = new AccountController();
            //var oldRole = account.UserManager.GetRoles(id);

            userManager.RemoveFromRole(id, role);
            db.SaveChanges();
            //return userManager;
        }


        #region AccountStuff
        public IEnumerable<ApplicationUser> ApplicationUsers()
        {
            return db.Users.ToList();
        }

        public List<IdentityRole> RolesList()
        {
            return db.Roles.ToList();
        }

        public IdentityRole GetSpecificRole(string roleName)
        {
            return db.Roles.Single(r => r.Name == roleName);
        }

        public List<IdentityRole> AddRole(FormCollection collection)
        {
            db.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
            {
                Name = collection["RoleName"]
            });
            db.SaveChanges();
            return db.Roles.ToList();
        }

        public IEnumerable<RoleViewModel> IndexRoleViewModel()
        {
            List<RoleViewModel> viewModel = new List<RoleViewModel>();

            foreach (IdentityRole role in db.Roles.ToList())
            {
                viewModel.Add(new RoleViewModel
                {
                    RoleName = role.Name,
                });
            }
            return viewModel;
        }

 public void InviteUserToInterview(string groupId, string AppId)
        {
            //Group NewUserGroup = GetSpecificGroup(groupId); //Hämtat grupp
            ApplicationUser appUser = GetSpecificUser(AppId); //Hämta user från ID
            //NewUserGroup.Users.Add(appUser); //Lägg till User i Gruppens lista av Users
            //appUser.Groups.Add(NewUserGroup); //Lägg till Grupp i Users lista av Grupper
            //db.Entry(NewUserGroup).State = System.Data.Entity.EntityState.Modified; //Entity state Modified
            db.Entry(appUser).State = System.Data.Entity.EntityState.Modified; //Entity state Modified
            db.SaveChanges();
        }

public IEnumerable<UserViewModel> UserViewModelsByGroupId(int? id)
        {
            List<UserViewModel> viewModels = new List<UserViewModel>();
            Group group = db.Groups.Single(d => d.Id == id);
            Department dep = db.Departments.Single(d => d.Id == group.DepartmentId);
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            ICollection<ApplicationUser> users = db.Groups.Single(u => u.Id == id).Users;
            //IList<string> UserRoles = userManager.GetRoles(user.Id);

            foreach (ApplicationUser user in users.ToList())
            {
                if (users.Count > 0)
                {
                    IList<string> UserRoles = userManager.GetRoles(user.Id);
                    if (UserRoles.Count == 0)
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
                                ZipCode = user.Adress.ZipCode,
                                DepartmentId = group.DepartmentId,
                                DName = dep.Name,
                                UserRole = ""
                            });
                        }
                        else
                        {
                            viewModels.Add(new UserViewModel
                            {
                                Email = user.Email,
                                Number = user.PhoneNumber,
                                DepartmentId = group.DepartmentId,
                                DName = dep.Name,
                                UserRole = ""
                            });
                        }
                    }
                    foreach (string role in UserRoles)
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
                                ZipCode = user.Adress.ZipCode,
                                DepartmentId = group.DepartmentId,
                                DName = dep.Name,
                                UserRole = role
                            });
                        }
                        else
                        {
                            viewModels.Add(new UserViewModel
                            {
                                Email = user.Email,
                                Number = user.PhoneNumber,
                                DepartmentId = group.DepartmentId,
                                DName = dep.Name,
                                UserRole = role
                            });
                        }
                    }

                }
                else
                {
                    viewModels.Add(new UserViewModel
                    {
                        Email = user.Email,
                        Number = user.PhoneNumber,
                        DepartmentId = group.DepartmentId,
                        UserRole = ""
                    });
                }
            }

            return viewModels;

        }

        public IEnumerable<UserViewModel> UserViewModels()
        {
            List<UserViewModel> viewModels = new List<UserViewModel>();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            foreach (ApplicationUser user in db.Users.ToList())
            {
                if (db.Users.ToList().Count > 0)
                {
                    IList<string> UserRoles = userManager.GetRoles(user.Id);
                    if (UserRoles.Count == 0)
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
                                ZipCode = user.Adress.ZipCode,
                                UserRole = ""
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
                    foreach (string role in UserRoles)
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
                                    ZipCode = user.Adress.ZipCode,
                                    UserRole = role
                                });
                        }
                        else
                        {
                            viewModels.Add(new UserViewModel
                            {
                                Email = user.Email,
                                Number = user.PhoneNumber,
                                UserRole = role
                            });
                        }
                    }
                }
                else
                {
                    viewModels.Add(new UserViewModel
                    {
                        Email = user.Email,
                        Number = user.PhoneNumber,
                        UserRole = ""
                    });
                }
            }
            return viewModels;

        }

        public IEnumerable<UserViewModel> UserViewModelsApplicants()
        {
            List<UserViewModel> viewModels = new List<UserViewModel>();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            foreach (ApplicationUser user in db.Users.ToList())
            {
                if (db.Users.ToList().Count > 0)
                {
                    IList<string> UserRoles = userManager.GetRoles(user.Id);
                    if (UserRoles.Count == 0)
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
                                ZipCode = user.Adress.ZipCode,
                                UserRole = ""
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
                    foreach (string role in UserRoles)
                    {
                        if (role == "applicant")
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
                                    ZipCode = user.Adress.ZipCode,
                                    UserRole = role
                                });
                            }
                            else
                            {
                                viewModels.Add(new UserViewModel
                                {
                                    Email = user.Email,
                                    Number = user.PhoneNumber,
                                    UserRole = role
                                });
                            }
                        }
                    }
                }
                else
                {
                    viewModels.Add(new UserViewModel
                    {
                        Email = user.Email,
                        Number = user.PhoneNumber,
                        UserRole = ""
                    });
                }
            }
            return viewModels;

        }
        public void SaveCV(string id, CV cv)
        {
            db.Users.Single(i => i.Id == id).CV = cv;
            db.SaveChanges();
        }

        public void DeleteCV(CV cv)
        {
            db.CVs.Remove(cv);
            db.SaveChanges();
        }
        public void SaveDocument(string id, CV cv)
        {
            db.Users.Single(i => i.Id == id).CV = cv;
            db.SaveChanges();
        }

        public void DeleteDocument(CV cv)
        {
            db.CVs.Remove(cv);
            db.SaveChanges();
        }
        #endregion

        #region Jobstuff
        // CREATE A LIST OF TYPE JOB, CALLED JOBS
        public IEnumerable<Job> Jobs()
        {
            return db.Jobs.ToList();
        }

        // SELECT A SPECIFIC JOB FROM MATCHING ID
        public Job GetJob(int? JobId)
        {
            return db.Jobs.Single(d => d.Id == JobId);
        }

        // CREATE NEW JOB AND ADD TO DATABASE
        public Job CreateJob(Job job)
        {
            db.Jobs.Add(job);
            db.SaveChanges();
            return job;
        }

        // EDIT SPECIFIC JOB
        public Job EditJob(Job job)
        {
            db.Entry(job).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return job;
        }

        // DELETE JOB
        public Job DeleteJob(Job job)
        {
            db.Jobs.Remove(job);
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

        public IEnumerable<DetailsDepartmentViewModel> DetailsDepartmentViewModelByDepartmentId(int? id)
        {
            List<DetailsDepartmentViewModel> viewModels = new List<DetailsDepartmentViewModel>();
            foreach (Group group in db.Departments.Single(u => u.Id == id).Groups.ToList())
            {
                viewModels.Add(new DetailsDepartmentViewModel
                {
                    Name = group.Name,
                    DepartmentId = (int)id
                });
            }
            return viewModels;

        }

        public IEnumerable<DetailsDepartmentViewModel> DetailsDepartmentViewModel()
        {
            List<DetailsDepartmentViewModel> viewModels = new List<DetailsDepartmentViewModel>();
            foreach (Group group in db.Groups.ToList())
            {
                viewModels.Add(new DetailsDepartmentViewModel
                {
                    Name = group.Name
                });
            }
            return viewModels;

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

        public ApplicationUser GetSpecificUser(string userId)
        {
            return db.Users.Single(d => d.Id == userId);
        }

        public Group GetSpecificGroup(int? groupId)
        {
            return db.Groups.Single(d => d.Id == groupId);
        }

        public IEnumerable<IndexGroupViewModel> IndexGroupViewModelByDepartmentId(int? id)
        {
            List<IndexGroupViewModel> viewModel = new List<IndexGroupViewModel>();

            foreach (Group group in db.Departments.Single(u => u.Id == id).Groups.ToList())
            {
                viewModel.Add(new IndexGroupViewModel
            {
                Id = group.Id,
                Name = group.Name,
                DepartmentId = (int)id,
                CompanyId = group.Department.Company.Id,
                Users = group.Users
            });
            }
            if (viewModel.Count == 0)
            {
                viewModel.Add(new IndexGroupViewModel
                {
                    Id = -1,
                    DepartmentId = (int)id,
                    CompanyId = db.Departments.Single(u => u.Id == id).Company.Id,
                    Users = null
                });
            }
            return viewModel;
        }

        public void AddUserToGroup(int? groupId, string AppId)
        {
            Group NewUserGroup = GetSpecificGroup(groupId); //Hämtat grupp
            ApplicationUser appUser = GetSpecificUser(AppId); //Hämta user från ID
            NewUserGroup.Users.Add(appUser); //Lägg till User i Gruppens lista av Users
            appUser.Groups.Add(NewUserGroup); //Lägg till Grupp i Users lista av Grupper
            db.Entry(NewUserGroup).State = System.Data.Entity.EntityState.Modified; //Entity state Modified
            db.Entry(appUser).State = System.Data.Entity.EntityState.Modified; //Entity state Modified
            db.SaveChanges();
        }

        //public void ChangeRoleOfUserInGroup(int? groupId, string userId)
        //{
        //    Group NewRoleInGroup = GetSpecificGroup(groupId); //Hämtat grupp
        //    ApplicationUser appUser = GetSpecificUser(userId); //Hämta user från ID
        //    NewRoleInGroup.Users.Add(appUser); //Lägg till User med ändrad roll i Gruppens lista av Users
        //    appUser.Groups.Add(NewRoleInGroup); //Lägg till Grupp i Users lista av Grupper med ändrad roll
        //    db.Entry(NewRoleInGroup).State = System.Data.Entity.EntityState.Modified; //Entity state Modified
        //    db.Entry(appUser).State = System.Data.Entity.EntityState.Modified; //Entity state Modified
        //    db.SaveChanges();
        //}
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

        public void AddScheduleToGroup(ScheduleWeek week, int? groupId)
        {
            db.Groups.Single(i => i.Id == groupId).Schedule.Add(week);
            db.SaveChanges();
        }
        #endregion

        public void Dispose()
        {
            db.Dispose();
        }
    }
}