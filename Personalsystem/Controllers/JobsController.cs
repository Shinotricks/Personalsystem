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
    public class JobsController : Controller
    {
        private PersonalsystemRepository repo = new PersonalsystemRepository();

        // GET: Jobs
        public ActionResult Index()
        {
            return View(repo.Jobs());
        }

        // GET: Jobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = repo.GetJob(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }
        
        // GET: Jobs/Create
        public ActionResult Create()
        {
            CreateJobViewModel tempVM = new CreateJobViewModel();
            tempVM.Company = repo.Companies().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
            return View(tempVM);
        } 
        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Published,Deadline,CompanyId")] CreateJobViewModel jobVM)
        {
            if (ModelState.IsValid)
            {
                //Gör om VM till riktigt objekt
                Job j = new Job();
                j.Name = jobVM.Name;
                j.Description = jobVM.Description;
                j.Deadline = jobVM.Deadline;
                //Använd repo för att lägga till i db
                repo.CreateJob(j);
                //Återvänd till företagsdetalj
                return RedirectToAction("Index", new { id = j.Id });
            }
            return View(jobVM);
        }
        // GET: Jobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = repo.GetJob(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET JOBS/DELETE
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = repo.GetJob(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job  = repo.GetJob(id);

            repo.DeleteJob(job);

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
