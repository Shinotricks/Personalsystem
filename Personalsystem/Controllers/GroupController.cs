using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Personalsystem.Models;
using Personalsystem.Repositories;

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
