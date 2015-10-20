using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Personalsystem.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Company Name")]
        public string Name { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }

    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Department Name")]
        public string Name { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }

    public class Group
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Group Name")]
        public string Name { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
        [ForeignKey("Schedule")]
        public int? ScheduleId   { get; set; }
        public virtual ICollection<ScheduleWeek> Schedule { get; set; }
    }

    public class News
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
    }

    // THIS IS VACANCIES, MEANING, JOBS THAT USERS CAN APPLY TO
    public class Job
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Job Name")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Published { get; set; }
        public DateTime Deadline { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
    }

    // THIS IS FOR APPLYING TO VACANCIES
    public class JobApplication
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ApplicationText { get; set; }
        [Required]
        public DateTime Published { get; set; }
        [Required]
        public int JobId { get; set; }
        [ForeignKey("JobId")]
        public virtual Job Job { get; set; }
    }

    public class ScheduleDay
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }

    public class ScheduleWeek
    {
        [Key]
        public int Id { get; set; }
        public ScheduleDay Monday { get; set; }
        public ScheduleDay Tuesday { get; set; }
        public ScheduleDay Wednesday { get; set; }
        public ScheduleDay Thursday { get; set; }
        public ScheduleDay Friday { get; set; }
        public ScheduleDay Saturday { get; set; }
        public ScheduleDay Sunday { get; set; }
    }

}