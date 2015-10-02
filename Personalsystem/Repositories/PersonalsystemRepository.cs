using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Personalsystem.Models;

namespace Personalsystem.Repositories
{
    public class PersonalsystemRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public PersonalsystemRepository()
        {
            db = new ApplicationDbContext();
        }

        #region Company Methods
        public IEnumerable<Company> Companies()
        {
            return db.Companies.ToList();
        }

        public Company GetSpecificCompany(int? companyId)
        {
            return db.Companies.Single(d => d.Id == companyId);
        }

        public Company CreateCompany(Company company)
        {
            db.Companies.Add(company);
            db.SaveChanges();

            return company;
        }

        public Company EditCompany(Company company)
        {
            db.Entry(company).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return company;
        }

        public Company RemoveCompany(Company company)
        {
            db.Companies.Remove(company);
            db.SaveChanges();

            return company;
        }
        #endregion

        #region Department Methods
        public IEnumerable<Department> Departments()
        {
            return db.Departments.ToList();
        }

        public IEnumerable<Department> GetDepartmentsByCompanyId(int? id)
        {
            return db.Departments.Where(i => i.CompanyId == id).ToList();
        }

        public Department GetSpecificDepartment(int? departmentId)
        {
            return db.Departments.Single(d => d.Id == departmentId);
        }

        #endregion

        #region Group Methods
        public IEnumerable<Group> Groups()
        {
            return db.Groups.ToList();
        }
        #endregion

        public void Dispose()
        {
            db.Dispose();
        }
    }
}