using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testurl2.Models;

namespace testurl2.Services
{
    public class CompanyServices : ICompanyServices
    {
        private readonly ICompanyRepo _companyRepo;
        public CompanyServices(ICompanyRepo companyRepo)
        {
            _companyRepo = companyRepo;
        }
        public Company Add(Company company)
        {
            var Company = _companyRepo.Add(company);
            return Company;
        }
        public Company Update(Company company)
        {
            var Company = _companyRepo.Update(company);
            return Company;
        }
        public Company Get(int id)
        {
            var company = _companyRepo.Get(id);
            return company;
        }
        public IEnumerable<Company> GetAll()
        {
            var companies = _companyRepo.GetAll();
            return companies;
        }
        public void Remove(int id)
        {
            _companyRepo.Remove(id);
        }
    }
}
