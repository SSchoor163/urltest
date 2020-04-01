using System.Collections.Generic;
using testurl3.Models;

namespace testurl3.Services
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