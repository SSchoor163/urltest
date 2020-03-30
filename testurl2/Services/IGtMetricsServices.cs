using System.Threading.Tasks;
using testurl2.Models;

namespace testurl2.Services
{
    public interface IGtMetricsServices
    {
        Task<GtMetrics> PostTest(string url, int companyId);
    }
}