using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testurl2.Models;
using testurl2.Services;

namespace testurl2
{
    public class DbInitializer
    {
        private readonly IGtMetricsRepo _GtMetricsRepo;
        private readonly ICompanyRepo _CompanyRepo;
        public DbInitializer(IGtMetricsRepo gtMetricsRepo, ICompanyRepo _companyRepo)
        {
            _GtMetricsRepo = gtMetricsRepo;
            _CompanyRepo = _companyRepo;
        }

        public void Initialize()
        {
            AddCompanies();
        }

        public void AddCompanies()
        {
            if (_CompanyRepo.GetAll().Count() > 0) return;
            Company initial = new Company
            {
                Id = 1,
                BusinessType = "Agriculture Equipment",
                City = "Grapevine",
                CompanyName = "Kubota Tractor",
                ConfirmedVersionDate = new DateTime(2019, 9, 21),
                Contacted = false,
                Country = "United States",
                EndEnterpriseSupport = null,
                GtMetricsId = null,
                Notes = string.Empty,
                PreviousVersion = null,
                RankingScale = 1,
                SfVersion = 11.1,
                SitefinityRetirmentDate = null,
                State_Region = "Texas",
                Street = "1000 Kubota Drive",
                Url = "kubotausa.com",
                ZipCode = "76051"
            };
            _CompanyRepo.Add(initial);
        }

    }
}
