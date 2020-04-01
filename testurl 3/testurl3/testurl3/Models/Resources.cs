using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testurl3.Models
{
    public class Resources
    {
        public string screenshot { get; set; } // URL to download the screenshot  string
        public string har { get; set; }//URL to download the HAR file.Note that sensitive info (HTTP auth and cookies) has been removed, file contents have been trimmed, and ring    sourege    datahas been included in the HAR file.   string
        public string pagespeed { get; set; } // URL to download the PageSpeed beacon    string
        public string pagespeed_files { get; set; }//URL to download the PageSpeed optimized files. The files are combined into a single tar file.   string
        public string yslow { get; set; }//URL to download the YSlow beacon    string
        public string report_pdf { get; set; }//The URL to the GTmetrix report in PDF format    string
        public string report_pdf_full { get; set; }//The URL to the full GTmetrix report (includes recommendation details) in PDF format string
        public string video { get; set; }//The URL to the optional GTmetrix video in MP4 format    string
        public string filmstrip { get; set; }//The URL to the optional GTmetrix video's filmstrip in JPEG format	string
    }
}
