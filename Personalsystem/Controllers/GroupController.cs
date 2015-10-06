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
        public ActionResult Index()
        {
            //var groups = repo.Groups.Include(g => g.Department);
            return View(repo.Groups());
        }
        // GET: Groups/Details/5
        public ActionResult Details(int? id)
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
        // GET: Groups/Create
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
