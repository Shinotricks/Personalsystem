using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Personalsystem.Models;
using System.Web.Mvc;

namespace Personalsystem.Viewmodels
{
    public class CreateJobViewModel
    {
            [Display(Name = "Job Name")]
            public string Name { get; set; }
            public string Description { get; set; }
            public DateTime Deadline { get; set; }

            public IEnumerable<SelectListItem> Company { get; set; }
    }
}