using System.Collections.Generic;
using testurl2.Models;

namespace testurl2.Services
{
    public interface ICompanyRepo
    {
        Company Add(Company newCompany);
        Company Get(int companyId);
        IEnumerable<Company> GetAll();
        void Remove(int companyId);
        Company Update(Company newCompany);
    }
}