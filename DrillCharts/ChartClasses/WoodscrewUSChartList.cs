using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Reflection;
using System.Diagnostics;

namespace DrillCharts
{
    public class WoodscrewUSChartList : List<WoodscrewUSChartRow>
    {
        public WoodscrewUSChartList()
        {
            GetBaseList("DrillCharts.Charts.woodscrewus.html");
        }

        public WoodscrewUSChartList(string docName)
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

            List<WoodscrewUSChartRow> list = this;

            int index = 0;

            foreach (XElement de in doc.Root.Elements())
            {
                WoodscrewUSChartRow row = new WoodscrewUSChartRow();

                row.index = index;

                int j = 0;
                foreach (XElement c in de.Elements())
                {
                    string strValue = c.Value; //.Replace(@"""", @"&quot;");
                    switch (j)
                    {
                        case 0: row.size = strValue; break;
                        case 1: row.outdia = strValue; break;
                        case 2: row.closedrill = strValue; break;
                        case 3: row.pilotsoft = strValue; break;
                        case 4: row.pilothard = strValue; break;
                    }
                    j++;
                }

                list.Add(row);
                index++;
            }

            return (true);
        }
    }
}
