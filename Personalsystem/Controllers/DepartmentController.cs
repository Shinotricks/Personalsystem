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
using Personalsystem.Viewmodels;

namespace Personalsystem.Controllers
{
    public class DepartmentController : Controller
    {
        private PersonalsystemRepository repo = new PersonalsystemRepository();

        //// GET: Departments
        //public ActionResult Index()
        //{
        //    return View(repo.Departments());
        //}

        // GET: Departments
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.CompanyId = id;
            ViewBag.Company = repo.GetSpecificCompany(id).Name;
            return View(repo.GetDepartmentsByCompanyId(id));
        }

        // GET: Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = repo.GetSpecificDepartment(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        public ActionResult CreateSchedule(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var groups = repo.GetGroupsByDepartmentId(id);
            if (groups == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CreateScheduleDepartmentViewModel
            {
                Groups = groups
            };
            ViewBag.DepartmentId = id;

            return View(viewModel);
        }

        // GET: Departments/Create
        public ActionResult Create(int? id)
        {
            ViewBag.CompanyId = id;
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CompanyId")] Department department)
        {
            if (ModelState.IsValid)
            {
                repo.CreateDepartment(department);
                return RedirectToAction("Index");
            }

            //ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", department.CompanyId);
            return View(department);
        }
        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = repo.GetSpecificDepartment(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", department.CompanyId);
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CompanyId")] Department department)
        {
            if (ModelState.IsValid)
            {
                repo.EditDepartment(department);
                return RedirectToAction("Index");
            }
            //ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", department.CompanyId);
            return View(department);
        }


        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = repo.GetSpecificDepartment(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }
        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = repo.GetSpecificDepartment(id);
            repo.RemoveDepartment(department);
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
