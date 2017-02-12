using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Reflection;
using System.Diagnostics;


namespace DrillCharts
{
    public class TapMetricChartList : List<TapMetricChartRow>
    {
        public TapMetricChartList()
        {
            GetBaseList("DrillCharts.Charts.tapdrillchartmetric.html");
        }

        public TapMetricChartList(string docName)
        {
            GetBaseList(docName);
        }

        private Stream getEmbeddedStream(string strName)
        {
            string[] sa = this.GetType().GetTypeInfo().Assembly.GetManifestResourceNames();
            foreach (var s in sa)
                Debug.WriteLine(s);

            return (this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream(strName));
        }

        public bool GetBaseList(string docName)
        {
            XDocument doc = null;

            doc = XDocument.Parse((new StreamReader(getEmbeddedStream(docName)).ReadToEnd()));

            List<TapMetricChartRow> list = this;

            int index = 0;

            foreach (XElement de in doc.Root.Elements())
            {
                TapMetricChartRow row = new TapMetricChartRow();

                row.index = index;

                int j = 0;
                foreach (XElement c in de.Elements())
                {
                    string strValue = c.Value; //.Replace(@"""", @"&quot;");
                    switch (j)
                    {
                        case 0: row.outdia = strValue; break;
                        case 1: row.tpi = strValue; break;

                        case 2: row.mm75 = strValue; break;
                        case 3: row.us75 = strValue; break;

                        case 4: row.mm50 = strValue; break;
                        case 5: row.us50 = strValue; break;

                        case 6: row.closemm = strValue; break;
                        case 7: row.closeus = strValue; break;
                        case 8: row.freemm = strValue; break;
                        case 9: row.freeus = strValue; break;
                    }
                    row.name = row.outdia + " x " + row.tpi;

                    j++;
                }

                list.Add(row);
                index++;
            }

            return (true);
        }
    }
}
