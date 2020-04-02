using System.Collections.Generic;
using System.Threading.Tasks;
using testurl3.Models;

namespace testurl3.Services
{
    public interface IGtMetricsServices
    {
        GtMetrics Add(GtMetrics gtMetric);
        GtMetrics Get(int id);
        IEnumerable<GtMetrics> GetAll();
        void Remove(int id);
        Task<GtMetrics> Test(string url, int companyId);
    }
}