using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testurl2.Models
{
    public class GtMetrics
    {
        public int Id { get; set; }
        public string Error { get; set; }
        public string ReportUrl { get; set; }
        public int PageSpeedScore { get; set; }
        public int YSlowScore { get; set; }
        public int HtmlBytes { get; set; }
        public int HtmlLoadTime { get; set; }
        public int PageBytes { get; set; }
        public int PageLoadTime { get; set; }
        public int PageElements { get; set; }
        public int RedirectDuration { get; set; }
        public int ConnectionDuration { get; set; }
        public int BackendDuration { get; set; }
        public int FirstPaintTime { get; set; }
        public int FirstContentfulPaintTime { get; set; }
        public int DomInteractiveTime { get; set; }
        public int DomContentLoadedTime { get; set; }
        public int DomContentLoadedDuration { get; set; }
        public int OnloadTime { get; set; }
        public int FullyLoadedTime { get; set; }
        public int RumSpeedIndex { get; set; }
        public string Screenshot { get; set; }
        public string HARFile { get; set; }
        public string PageSpeed { get; set; }
        public string PageSpeedFiles { get; set; }
        public string YSlow { get; set; }
        public string ReportPdf { get; set; }
        public string ReportPdfFull { get; set; }
        public string Video { get; set; }
        public string FilmStrip { get; set; }
        public int CompanyId { get; set; }
    }
}
