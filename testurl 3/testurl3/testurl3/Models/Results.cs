using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testurl3.Models
{
    public class Results
    {
        public string report_url { get; set; }// The URL to the GTmetrix report
        public int? pagespeed_score { get; set; } //PageSpeed score 
        public int? yslow_score { get; set; } //YSlow score 
        public int? html_bytes { get; set; }//The HTML size(may be the compressed size) 
        public int? html_load_time { get; set; }//The HTML load time or TTFB (in milliseconds)    
        public int? page_bytes { get; set; }//The total page size 
        public int? page_load_time { get; set; }//The page load time (in milliseconds)    
        public int? page_elements { get; set; }//The number of page elements (# of resources)
        public int?  redirect_duration { get; set; }//Time spent redirecting (in milliseconds)    
        public int? connect_duration { get; set; }//Connection time for the html page request (in milliseconds). This timing is a sum of blocked, DNS, connect and send t nii ad  ay    be 0 if the request was redirected.integer
        public int? backend_duration { get; set; }//Backend or wait time for the html page request (in milliseconds)    integer
        public int? first_paint_time { get; set; }//First paint time (in milliseconds)  integer
        public int? first_contentful_paint_time { get; set; }// First contentful paint time (in milliseconds)   integer
        public int? dom_interactive_time { get; set; }//  DOM interactive time (in milliseconds)  integer
        public int? dom_content_loaded_time { get; set; }// DOM content loaded time (in milliseconds)   integer
        public int?  dom_content_loaded_duration { get; set; }// DOM content loaded duration (in milliseconds). The duration of which the DOMContentLoaded event JavaScript t tan io    complete.integer
        public int? onload_time { get; set; }// Window.onload time (in milliseconds); same as results.page_load_time integer
        public int? onload_duration { get; set; }// Window.onload duration (in milliseconds). The duration of which the window.onload event JavaScript takes to t coete.integer
        public int? fully_loaded_time { get; set; }//Fully loaded time (in milliseconds). The time after the window.onload event has fired and there has been no network activity for 2 seconds.If the x-metrix-stop-onload option is used, then this value will be set to -1.	integer
        public int? rum_speed_index { get; set; }//RUM Speed Index integer
    }
}
