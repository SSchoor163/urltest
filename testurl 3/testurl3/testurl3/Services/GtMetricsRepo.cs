using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testurl3.Models;

namespace testurl3.Services
{
    public class GtMetricsRepo : IGtMetricsRepo
    {
        private readonly AppDbContext _dbContext;
        public GtMetricsRepo(AppDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public GtMetrics Add(GtMetrics newMetric)
        {
            _dbContext.GtMetrics.Add(newMetric);
            _dbContext.SaveChanges();
            return newMetric;
        }
        public GtMetrics Update(GtMetrics newMetric)
        {
            var ExistingMetric = _dbContext.GtMetrics
                .FirstOrDefault(M => M.CompanyId == newMetric.CompanyId);
            if (ExistingMetric == null) return null;
            _dbContext.Entry(ExistingMetric).CurrentValues
                .SetValues(newMetric);
            _dbContext.Update(ExistingMetric);
            _dbContext.SaveChanges();
            return newMetric;

        }
        public GtMetrics Get(int companyId)
        {
            
            GtMetrics Metric = _dbContext.GtMetrics.FirstOrDefault(m => m.CompanyId == companyId);
            if (Metric == null) return null;
            return Metric;
        }
        public IEnumerable<GtMetrics> GetAll()
        {
            var Metrics = _dbContext.GtMetrics;
            if (Metrics == null) return null;
            return Metrics;
        }
        public void Remove(int companyId)
        {
            var ExistingMetric = _dbContext.GtMetrics.FirstOrDefault(m => m.CompanyId == companyId);
            if (ExistingMetric == null) throw new SystemException("The Restaurant you are trying to delete was not found.");
            _dbContext.GtMetrics.Remove(ExistingMetric);
            _dbContext.SaveChanges();
        }
    }
}
