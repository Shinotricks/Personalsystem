using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personalsystem.Models
{
    public class Company
    {
        int Id { get; set; }
        //todo: ledning
        IEnumerable<Department> Departments;
    }

    public class Department
    {
        int Id { get; set; }
        IEnumerable<Group> Groups;
    }

    public class Group
    {
        int Id { get; set; }
        IEnumerable<ApplicationUser> Users;
    }

    public class News
    {
        int Id { get; set; }
        string Text { get; set; }
    }
}