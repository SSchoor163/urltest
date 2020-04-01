using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testurl3.Models
{
    public class GtMetricsDomainModel
    {
        public string state { get; set; }// The current state of the test string (queued, started, completed, error)
        public string error { get; set; }// The error message if state == "error". Empty string if no error.
        public Results results { get; set; }
        public Resources resources { get; set; }

    }
}
