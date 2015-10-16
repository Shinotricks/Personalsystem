using Personalsystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personalsystem.Viewmodels
{
    public class CreateScheduleDepartmentViewModel
    {
        public IEnumerable<Group> Groups { get; set; }
        public ScheduleWeek Week { get; set; }
    }

    public class CreateScheduleGroupViewModel
    {
        public Group Group { get; set; }
        public ScheduleWeek Week { get; set; }
    }
}