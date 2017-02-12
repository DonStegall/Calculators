using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Reflection;
using System.Diagnostics;

namespace DrillCharts
{
    public class DrillChartList : List<DrillChartRow>
    {
        public DrillChartList()
        {
            GetBaseList("DrillCharts.Charts.drillchart.html");
        }

        private Stream getEmbeddedStream(string strName)
        {
            string[] sa = this.GetType().GetTypeInfo().Assembly.GetManifestResourceNames();
            foreach (var s in sa)
                Debug.WriteLine(s);

            return (this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream(strName));
        }

        public DrillChartList(string docName)
        {
            GetBaseList(docName);
        }

        public bool GetBaseList(string docName)
        {
            XDocument doc = null;

            doc = XDocument.Parse((new StreamReader(getEmbeddedStream(docName)).ReadToEnd()));

            List<DrillChartRow> list = this;

            int index = 0;

            foreach (XElement de in doc.Root.Elements())
            {
                DrillChartRow row = new DrillChartRow();

                row.index = index;

                int j = 0;
                foreach (XElement c in de.Elements())
                {
                    string strValue = c.Value;
                    switch (j)
                    {
                        case 0: row.rowtype = strValue; break;
                        case 1: row.size = strValue; break;
                        case 2: row.inches = strValue; break;
                        case 3: row.millimeters = strValue; break;
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
