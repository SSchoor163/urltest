using System.Collections.Generic;
using testurl2.Models;

namespace testurl2.Services
{
    public interface IGtMetricsRepo
    {
        GtMetrics Add(GtMetrics newMetric);
        GtMetrics Get(int companyId);
        IEnumerable<GtMetrics> GetAll();
        void Remove(int companyId);
        GtMetrics Update(GtMetrics newMetric);
    }
}