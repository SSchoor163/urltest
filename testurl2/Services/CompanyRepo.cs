using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testurl2.Models;

namespace testurl2.Services
{
    public class CompanyRepo : ICompanyRepo
    {
        private readonly AppDbContext _dbContext;
        public CompanyRepo(AppDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public Company Add(Company newCompany)
        {
            _dbContext.Companies.Add(newCompany);
            _dbContext.SaveChanges();
            return newCompany;
        }
        public Company Update(Company newCompany)
        {
            var ExistingCompany = _dbContext.Companies
                .FirstOrDefault(c => c.Id == newCompany.Id);
            if (ExistingCompany == null) return null;
            _dbContext.Entry(ExistingCompany).CurrentValues
                .SetValues(newCompany);
            _dbContext.Update(ExistingCompany);
            _dbContext.SaveChanges();
            return newCompany;

        }
        public Company Get(int companyId)
        {
            var comapny = _dbContext.Companies.FirstOrDefault(c => c.Id == companyId);
            if (comapny == null) return null;
            return comapny;
        }
        public IEnumerable<Company> GetAll()
        {
            var company = _dbContext.Companies;
            if (company == null) return null;
            return company;
        }
        public void Remove(int companyId)
        {
            var ExistingCompany = _dbContext.Companies.FirstOrDefault(c => c.Id == companyId);
            if (ExistingCompany == null) throw new SystemException("The Company you are trying to delete was not found.");
            _dbContext.Companies.Remove(ExistingCompany);
            _dbContext.SaveChanges();
        }
    }
}
