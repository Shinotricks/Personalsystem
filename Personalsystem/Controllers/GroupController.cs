using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Personalsystem.Models;
using Personalsystem.Repositories;
using Personalsystem.Viewmodels;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace Personalsystem.Controllers
{
    public class GroupController : Controller
    {
        private PersonalsystemRepository repo = new PersonalsystemRepository();

        // GET: Groups
        public ActionResult Index(int? id, int? Cid)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.DepartmentId = id;
            ViewBag.DepartmentName = repo.GetSpecificDepartment(id).Name;
            ViewBag.CompanyId = Cid;
            return View(repo.IndexGroupViewModelByDepartmentId(id));
        }

        // GET: Users
        public ActionResult Users(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var group = repo.GetSpecificGroup(id);

            if (group == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupName = group.Name;
            return View(repo.UserViewModelsByGroupId(id));
        }

        public ActionResult CreateSchedule(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var group = repo.GetSpecificGroup(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CreateScheduleGroupViewModel
            {
                Group = group
            };

            return View(viewModel);
        }

        // GET: Schedule
        public ActionResult Schedule(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (repo.GetSpecificGroup(id).Schedule.Count == 0)
            {
                var week = new ScheduleWeek();
                week.Monday = new ScheduleDay
                {
                    Start = new DateTime(2015, 10, 08, 9, 0, 0),
                    End = new DateTime(2015, 10, 08, 4, 0, 0)
                };
                week.Tuesday = new ScheduleDay
                {
                    Start = new DateTime(2015, 10, 09, 9, 0, 0),
                    End = new DateTime(2015, 10, 09, 4, 0, 0)
                };
                week.Wednesday = new ScheduleDay
                {
                    Start = new DateTime(2015, 10, 10, 9, 0, 0),
                    End = new DateTime(2015, 10, 10, 4, 0, 0)
                };
                week.Thursday = new ScheduleDay
                {
                    Start = new DateTime(2015, 10, 11, 9, 0, 0),
                    End = new DateTime(2015, 10, 11, 4, 0, 0)
                };
                week.Friday = new ScheduleDay
                {
                    Start = new DateTime(2015, 10, 12, 9, 0, 0),
                    End = new DateTime(2015, 10, 12, 4, 0, 0)
                };
                repo.AddScheduleToGroup(week, id);
            }
            return View(repo.GetSpecificGroup(id).Schedule);
        }

        // GET: InviteToInterview
        [Authorize(Roles = "admin")]
        public ActionResult InviteUserToInterview(string mail)
        {
            if (mail == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = new ApplicationUser();
            var uId = repo.ApplicationUsers().Single(m => m.Email == mail).Id;
            user = repo.GetSpecificUser(uId);

            if (user == null)
            {
                return HttpNotFound();
            }
            //SKapa VM instans
            UserViewModel inviteVM = new UserViewModel();
            //Bind detta ID till Viewmodell

            ViewBag.Id = user.Id;
            inviteVM.Email = repo.ApplicationUsers().Single(m => m.Email == mail).Email;
            //Returna View med VM
            return View(inviteVM);
        }

        // POST: InviteToInterview
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InviteUserToInterview([Bind(Include = "Email, Number, Street, StreetNumber, ZipCode, City, UserRole")] UserViewModel invitedUser)
        {
            if (ModelState.IsValid)
            {
                //ViewBag.groupName = invitedUsers.Name;
                //repo.AddUserToGroup(invitedUser.Name, invitedUser.SelectedUser);
                //return RedirectToAction("../Group/Index/", depId);
                return View();
            }

            //ViewBag.DepartmentId = new SelectList(repo.GetGroupsByDepartmentId, "Id", "Name", group.DepartmentId);
            return View(invitedUser);
        }

        // GET: Group/InviteUsers
        [Authorize(Roles = "admin")]
        public ActionResult InviteUserForGroup(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = repo.GetSpecificGroup(id);
            ApplicationUser groupUser = new ApplicationUser();
            
            if (group == null)
            {
                return HttpNotFound();
            }
            //SKapa VM instans
            UserInviteViewModel inviteVM = new UserInviteViewModel();
            //Bind detta ID till Viewmodell

            inviteVM.Id = group.Id;
            inviteVM.Name = group.Name;
            inviteVM.Users = repo.ApplicationUsers().Where(g => g.Id == g.Id ).Select(u => new SelectListItem
            {
                Text = u.UserName,
                Value = u.Id
            });
            ViewBag.Name = group.Name;
            //Returna View med VM
            return View(inviteVM);
        }

        // POST: Group/InviteUser
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InviteUserForGroup([Bind(Include = "Id, SelectedUser")] UserInviteViewModel invitedUser)
        {
            if (ModelState.IsValid)
            {
                //ViewBag.groupName = invitedUsers.Name;
                Group group = repo.GetSpecificGroup(invitedUser.Id);
                int depId = group.DepartmentId;
                repo.AddUserToGroup(invitedUser.Id, invitedUser.SelectedUser);
                //return RedirectToAction("../Group/Index/", depId);
                return View();
            }

            //ViewBag.DepartmentId = new SelectList(repo.GetGroupsByDepartmentId, "Id", "Name", group.DepartmentId);
            return View(invitedUser);
        }

        // GET: Group/ChangeRoleOfUserInGroup
        [Authorize(Roles = "admin")]
        public ActionResult ChangeRoleOfUserInGroup(string mail)
        {
            //SKapa VM instans
            UserChangeRoleViewModel changeVM = new UserChangeRoleViewModel();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            //Välj en user till Viewmodell
            //ViewBag.Name = changeVM.Name;
            changeVM.Users = repo.ApplicationUsers().Select(u => new SelectListItem
            {
                Text = u.UserName,
                Value = u.Id,
            });
            //ApplicationUser usr = repo.ApplicationUsers().First();
            //Välj vilken av users roll som skall ändras
            //List<IdentityRole> cVM = new List<IdentityRole>();
            changeVM.SelectedUser = repo.ApplicationUsers().Single(m => m.Email == mail).Id;
            changeVM.OldRoles = userManager.GetRoles(changeVM.SelectedUser).Select(o => new SelectListItem
            {
                Text = o,
                Value = o
            });
            //Välj en ny roll till Viewmodell
            changeVM.Roles = repo.RolesList().Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Name
            });
            //Returna View med VM
            return View(changeVM);
        }

        // POST: Group/ChangeRoleOfUserInGroup
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeRoleOfUserInGroup([Bind(Include = "SelectedUser, SelectedRole, SelectedOldRole")] UserChangeRoleViewModel changedRole)
        {
            if (ModelState.IsValid)
            {
                //ViewBag.Name = changedRole.Name;


                ApplicationUser user = new ApplicationUser();
                user.UserName = changedRole.SelectedUser;
                //var account = new AccountController();
                //var role = System.Web.Security.Roles.GetRolesForUser().Single(); 
                //var role = account.UserManager.GetRoles(changedRole.SelectedUser.ToString());
                //repo.RemoveUserRole(user.UserName, changedRole.SelectedOldRoles);
                if (changedRole.SelectedOldRole != null)
                {
                    repo.RemoveUserRole(changedRole.SelectedUser, changedRole.SelectedOldRole);
                }
                repo.AddUserRole(changedRole.SelectedUser, changedRole.SelectedRole);
                return RedirectToAction("Users");
            }

            //ViewBag.DepartmentId = new SelectList(repo.GetGroupsByDepartmentId, "Id", "Name", group.DepartmentId);
            return View(changedRole);
        }

        // GET: Groups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = repo.GetSpecificGroup(id);

            //ApplicationUser TestUser = new ApplicationUser { Email = "user2@usersson.dk", UserName = "user2@usersson.dk", PhoneNumber = "23456789" }; 
            //    repo.AddUserToGroup(1,TestUser);

            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }
        // GET: Groups/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            //ViewBag.DepartmentId = new SelectList(repo.Groups, "Id", "Name");
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,DepartmentId")] Group group)
        {
            if (ModelState.IsValid)
            {
                repo.CreateGroup(group);
                return RedirectToAction("Index");
            }

            //ViewBag.DepartmentId = new SelectList(repo.GetGroupsByDepartmentId, "Id", "Name", group.DepartmentId);
            return View(group);
        }

        // GET: Groups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = repo.GetSpecificGroup(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            //ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", group.DepartmentId);
            return View(group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DepartmentId")] Group group)
        {
            if (ModelState.IsValid)
            {
                repo.EditGroup(group);
                return RedirectToAction("Index");
            }
            //ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", group.DepartmentId);
            return View(group);
        }

        // GET: Groups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = repo.GetSpecificGroup(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group group = repo.GetSpecificGroup(id);
            repo.RemoveGroup(group);
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
