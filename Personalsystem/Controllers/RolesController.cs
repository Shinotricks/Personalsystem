using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Personalsystem.Repositories;
using Personalsystem.Models;
using System.Web.Security;
using System.Net;
using Personalsystem.Viewmodels;

namespace Personalsystem.Controllers
{

    public class RolesController : Controller
    {
        private PersonalsystemRepository repo = new PersonalsystemRepository();

        // GET: Roles
        public ActionResult Index()
        {
            //var rolesList = new List<RoleViewModel>();
            //foreach (var role in repo.RolesList())
            //{
            //    var roleModel = new RoleViewModel();
            //    rolesList.Add(roleModel);
            //}
            return View(repo.IndexRoleViewModel());
            //return View(repo.RolesList());
        }
        // GET: /Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Roles/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            if (roleManager.RoleExists(collection["RoleName"]) == false)
            {
                Guid guid = Guid.NewGuid();
                roleManager.Create(new IdentityRole() { Id = guid.ToString(), Name = collection["RoleName"] });
                ViewBag.ResultMessage = "Role created successfully !";
            }
            return View();
        }

        // GET: Roles/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(string roleName)
        {
            if (roleName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityRole role = repo.GetSpecificRole(roleName);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult RoleDelete(string RoleName)
        {

            Roles.DeleteRole(RoleName);
            ViewBag.ResultMessage = "Role deleted succesfully !";


            return RedirectToAction("RoleIndex", "Account");
        }

        //public ActionResult Delete(string RoleName)
        //{
        //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        //    var thisRole = repo.GetSpecificRole(RoleName);
        //    roleManager.Delete(thisRole);
        //    ViewBag.ResultMessage = "Role deleted successfully !";
        //    return View();
        //}
    }
}