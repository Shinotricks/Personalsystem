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

namespace Personalsystem.Controllers
{
    public class GroupController : Controller
    {
        private PersonalsystemRepository repo = new PersonalsystemRepository();

        // GET: Groups
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.DepartmentId = id;
            ViewBag.DepartmentName = repo.GetSpecificDepartment(id).Name;
            return View(repo.Groups());
        }

        // GET: Users
        public ActionResult Users(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var group = repo.GetSpecificGroup(id);

            ViewBag.GroupName = group.Name;
            ViewBag.DepartmentId = group.DepartmentId;
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

// GET: Group/InviteUsers
        [Authorize(Roles = "admin, applicant")]
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
            inviteVM.Users = repo.ApplicationUsers().Where(g => g.Id == g.Id ).Select(u => new SelectListItem
            {
                Text = u.UserName,
                Value = u.Id
            });
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
                repo.AddUserToGroup(invitedUser.Id, invitedUser.SelectedUser);
                return RedirectToAction("../Group/Index");
            }

            //ViewBag.DepartmentId = new SelectList(repo.GetGroupsByDepartmentId, "Id", "Name", group.DepartmentId);
            return View(invitedUser);
        }

        // GET: Group/ChangeRoleOfUserInGroup
        [Authorize(Roles = "admin, applicant")]
        public ActionResult ChangeRoleOfUserInGroup()
        {
            //SKapa VM instans
            UserChangeRoleViewModel changeVM = new UserChangeRoleViewModel(); 
            //Bind en user till Viewmodell
            //ViewBag.Name = changeVM.Name;
            changeVM.Users = repo.ApplicationUsers().Select(u => new SelectListItem
            {
                Text = u.UserName,
                Value = u.Id,
            });
            ApplicationUser usr = repo.ApplicationUsers().First();
            //Bind en role till Viewmodell
            changeVM.Roles = repo.Roles().Select(r => new SelectListItem
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
        public ActionResult ChangeRoleOfUserInGroup([Bind(Include = "SelectedUser, SelectedRole, OldRole")] UserChangeRoleViewModel changedRole)
        {
            if (ModelState.IsValid)
            {
                //ViewBag.Name = changedRole.Name;

                //ApplicationUser user = changedRole.SelectedUser;
                var account = new AccountController();
                //Roles.GetRolesForUser(User.Identity.Name);
                //var role = System.Web.Security.Roles.GetRolesForUser().Single(); 
                //var role = account.UserManager.GetRoles(changedRole.SelectedUser.ToString());
                repo.RemoveUserRole(changedRole.SelectedUser, changedRole.OldRole);

                repo.AddUserRole(changedRole.SelectedUser, changedRole.SelectedRole);
                return RedirectToAction("Index");
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
        [Authorize(Roles = "admin, applicant")]
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
