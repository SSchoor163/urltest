using testurl3.Models;

namespace testurl3.Services
{
    public interface ICompanyRepo
    {
        Company Add(Company newCompany);
        Company Get(int companyId);
        System.Collections.Generic.IEnumerable<Company> GetAll();
        void Remove(int companyId);
        Company Update(Company newCompany);
    }
}