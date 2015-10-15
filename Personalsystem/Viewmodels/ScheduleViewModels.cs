using Personalsystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personalsystem.Viewmodels
{
    public class CreateScheduleViewModel
    {
        public IEnumerable<Group> Groups { get; set; }
        public ScheduleWeek Week { get; set; }
    }
}