using System.Collections.Generic;
using testurl3.Models;

namespace testurl3.Services
{
    public interface ICompanyServices
    {
        Company Add(Company company);
        Company Get(int id);
        IEnumerable<Company> GetAll();
        void Remove(int id);
        Company Update(Company company);
    }
}