﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testurl2.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string BusinessType { get; set; }
        public string CompanyName { get; set; }
        public string Url { get; set; }
        public double SfVersion { get; set; }
        public DateTime? EndEnterpriseSupport { get; set; }
        public DateTime? SitefinityRetirmentDate { get; set; }
        public double? PreviousVersion { get; set; }
        public DateTime ConfirmedVersionDate { get; set; }
        public bool Contacted { get; set; }
        public string Notes { get; set; }
        public int RankingScale { get; set; }
        public string Country { get; set; }
        public string State_Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public int? GtMetricsId { get; set; }
        public GtMetrics GtMetric { get; set; }
    }
}
