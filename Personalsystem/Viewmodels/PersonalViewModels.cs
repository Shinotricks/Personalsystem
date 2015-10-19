﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Personalsystem.Models;
using System.Web.Mvc;

namespace Personalsystem.Viewmodels
{
    public class DepartmentCreateViewModel
    {
        [Required]
        [Display(Name = "Department Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Company ID")]
        public int CompanyId { get; set; }
    }

    public class GroupCreateViewModel
    {
        [Required]
        [Display(Name = "Group Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Department ID")]
        public int DepartmentId { get; set; }
    }
    public class DetailsDepartmentViewModel
    {
        [Required]
        [Display(Name = "Group Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Department ID")]
        public int DepartmentId { get; set; }

        [Required]
        [Display(Name = "Company ID")]
        public int CompanyId { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
    public class IndexGroupViewModel
    {
        [Display(Name = "Group Id")]
        public int Id { get; set; }

        [Display(Name = "Group Name")]
        public string Name { get; set; }

        [Display(Name = "Department ID")]
        public int DepartmentId { get; set; }

        [Display(Name = "Company ID")]
        public int CompanyId { get; set; }
    }
    public class UserInviteViewModel
    {
        [Required]
        [Display(Name = "Group Id")]
        public int Id { get; set; }

        //[Required]
        //[Display(Name = "Group Name")]
        //public string Name { get; set; }

        public IEnumerable<SelectListItem> Users { get; set; }
        public string SelectedUser { get; set; }

    }
    public class UserChangeRoleViewModel
    {
        [Display(Name = "Group Name")]
        public string Name { get; set; }

        public IEnumerable<SelectListItem> Users { get; set; }
        public string SelectedUser { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
        public string SelectedRole { get; set; }
        public string OldRole { get; set; }
    }
}