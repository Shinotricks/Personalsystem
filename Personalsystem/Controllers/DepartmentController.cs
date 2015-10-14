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

        // GET: Departments
        public ActionResult DetailsForDepartment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Group = repo.GetSpecificDepartment(id).Name;
            return View(repo.DetailsDepartmentViewModelByDepartmentId(id));
            //return View(repo.DetailsDepartmentViewModelByDepartmentId(id));
        }

        // GET: Departments/Details/5
        public ActionResult UsersDetailsForDepartment(int? id)
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
            //SKapa VM instans
            List<DetailsDepartmentViewModel> DepVM = new List<DetailsDepartmentViewModel>();
            //Bind detta ID till Viewmodell
            //DepVM.FirstOrDefault().Groups = department.Groups;
            //DepVM.Add(department.Id, department.Groups(department.Id ));
            //Returna View med VM
            return View(DepVM);
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

        // GET: Group/CreateGroup
        [Authorize(Roles = "admin, applicant")]
        public ActionResult CreateGroupForDepartment(int? id)
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
            //SKapa VM instans
            GroupCreateViewModel GroupVM = new GroupCreateViewModel();
            //Bind detta ID till Viewmodell
            GroupVM.DepartmentId = department.Id;
            //Returna View med VM
            return View(GroupVM);
        }

        // POST: Group/CreateGroup
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGroupForDepartment([Bind(Include = "DepartmentId, Name")] GroupCreateViewModel groupVM)
        {
            if (ModelState.IsValid)
            {
                //Gör om VM till riktigt objekt
                Group group = new Group();
                group.DepartmentId = groupVM.DepartmentId;
                group.Name = groupVM.Name;
                //Använd repo för att lägga till i db
                repo.CreateGroup(group);
                //Återvänd till företagsdetalj
                return RedirectToAction("Details", new { id = groupVM.DepartmentId });
            }
            return View();
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
            var viewModel = new CreateScheduleViewModel
            {
                Groups = groups
            };

            return View(viewModel);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            //ViewBag.CompanyId = repo.GetSpecificCompany(id);
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
