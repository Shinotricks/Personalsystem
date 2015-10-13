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
    public class CompanyController : Controller
    {
        private PersonalsystemRepository repo = new PersonalsystemRepository();
        
        // GET: Companies
        public ActionResult Index()
        {
            return View(repo.Companies());
        }

        // GET: Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = repo.GetSpecificCompany(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }
        
        // GET: Department/CreateDepartment
        [Authorize(Roles = "admin, applicant")]
        public ActionResult CreateDepartmentForCompany(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = repo.GetSpecificCompany(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            //SKapa VM instans
            DepartmentCreateViewModel DepVM = new DepartmentCreateViewModel();
            //Bind detta ID till Viewmodell
            DepVM.CompanyId = company.Id;
            //Returna View med VM
            return View(DepVM);
        }

        // POST: Department/CreateDepartment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDepartmentForCompany([Bind(Include = "CompanyID, Name")] DepartmentCreateViewModel depVM)
        {
            if (ModelState.IsValid)
            {
                //Gör om VM till riktigt objekt
                Department dep = new Department();
                dep.CompanyId = depVM.CompanyId;
                dep.Name = depVM.Name;
                //Använd repo för att lägga till i db
                repo.CreateDepartment(dep);
                //Återvänd till företagsdetalj
                return RedirectToAction("Details", new { id = depVM.CompanyId});
            }
            return View();
        }

        // GET: Company/Create
        [Authorize(Roles="admin, applicant")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Company company)
        {
            if (ModelState.IsValid)
            {
                repo.CreateCompany(company);
                return RedirectToAction("Index");
            }

            return View(company);
        }

        // GET: Companies/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = repo.GetSpecificCompany(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Company company)
        {
            if (ModelState.IsValid)
            {
                repo.EditCompany(company);
                return RedirectToAction("Index");
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = repo.GetSpecificCompany(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = repo.GetSpecificCompany(id);
            
            repo.RemoveCompany(company);

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
