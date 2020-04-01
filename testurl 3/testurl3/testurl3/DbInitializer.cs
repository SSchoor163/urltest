using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testurl3.Models;
using testurl3.Services;

namespace testurl3
{
    public class DbInitializer
    {
        private readonly IGtMetricsServices _gtMetricsServices;
        private readonly ICompanyRepo _CompanyRepo;
        public DbInitializer(ICompanyRepo _companyRepo, IGtMetricsServices gtMetrics)
        {
            _gtMetricsServices = gtMetrics;
            _CompanyRepo = _companyRepo;
        }

        public void Initialize()
        {
            AddCompanies();
            AddGtMetric();
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

        public void AddGtMetric()
        {
            if (_gtMetricsServices.GetAll().Count() > 0) return;
            GtMetrics initial = new GtMetrics();
            _gtMetricsServices.PostTest("kubotausa.com", 1);
        }
    }
}
