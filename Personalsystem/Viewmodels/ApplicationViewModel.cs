using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Personalsystem.Models;
using System.Web.Mvc;

namespace Personalsystem.Viewmodels
{
    public class ApplyForJobViewModel
    {
        public string Applicant { get; set; }
        public DateTime ApplicationDate { get; set; }
        public Job Job { get; set; }

    }
}