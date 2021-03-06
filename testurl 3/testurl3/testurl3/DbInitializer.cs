﻿using System;
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
           
            var Metric = MakeGtMetric();
            
            AddMetric(Metric.Result);

        }

        public void AddCompanies( GtMetrics metric)
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
                GtMetricsId = 1,
                GtMetrics = metric,
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

        public async Task<GtMetrics>  MakeGtMetric()
        {
            if (_gtMetricsServices.GetAll().Count() > 0) return null;
            
             GtMetrics initial = await _gtMetricsServices.Test("kubotausa.com", 1);
            return initial;
            
        }
        public void AddMetric(GtMetrics metric)
        {
            var exists = _gtMetricsServices.Get(1);
            if (exists == null)
                AddCompanies(metric);
        }
    }
}
