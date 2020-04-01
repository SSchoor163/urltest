using System.Collections.Generic;
using System.Threading.Tasks;
using testurl3.Models;

namespace testurl3.Services
{
    public interface IGtMetricsServices
    {
        GtMetrics Get(int id);
        IEnumerable<GtMetrics> GetAll();
        void Remove(int id);
        GtMetrics Update(GtMetrics gtMetric);
        Task<GtMetrics> PostTest(string url, int companyId);
    }
}