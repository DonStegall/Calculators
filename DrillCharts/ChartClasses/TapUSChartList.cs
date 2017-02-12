using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Reflection;
using System.Diagnostics;


namespace DrillCharts
{
    public class TapUSChartList : List<TapUSChartRow>
    {
        public TapUSChartList()
        {
            GetBaseList("DrillCharts.Charts.tapdrillchartus.html");
        }

        public TapUSChartList(string docName)
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

            List<TapUSChartRow> list = this;

            int index = 0;

            foreach (XElement de in doc.Root.Elements())
            {
                TapUSChartRow row = new TapUSChartRow();

                row.index = index;

                int j = 0;
                foreach (XElement c in de.Elements())
                {
                    string strValue = c.Value; //.Replace(@"""", @"&quot;");
                    switch (j)
                    {
                        case 0: row.size = strValue; break;
                        case 1: row.tpi = strValue; break;
                        case 2: row.name = strValue; break;
                        case 3: row.outdia = strValue; break;

                        case 4: row.drill100 = strValue; break;
                        case 5: row.dia100 = strValue; break;

                        case 6: row.drill75 = strValue; break;
                        case 7: row.dia75 = strValue; break;

                        case 8: row.drill50 = strValue; break;
                        case 9: row.dia50 = strValue; break;

                        case 10: row.closedrill = strValue; break;
                        case 11: row.closedia = strValue; break;
                        case 12: row.freedrill = strValue; break;
                        case 13: row.freedia = strValue; break;
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
