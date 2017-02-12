using System;
using System.Collections.Generic;
using System.Linq;

namespace DrillCharts
{
    public class TapMetricChartRow
    {
        public int index { get; set; }

        public string outdia { get; set; }
        public string tpi { get; set; }
        public string name { get; set; }

        public string mm75 { get; set; }
        public string us75 { get; set; }

        public string mm50 { get; set; }
        public string us50 { get; set; }

        public string closemm { get; set; }
        public string closeus { get; set; }
        public string freemm { get; set; }
        public string freeus { get; set; }
    }
}

