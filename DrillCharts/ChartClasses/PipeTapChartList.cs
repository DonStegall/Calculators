﻿using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Reflection;
using System.Diagnostics;

namespace DrillCharts
{
    public class PipeTapChartList : List<PipeTapChartRow>
    {
        public PipeTapChartList()
        {
            GetBaseList("DrillCharts.Charts.straightpipetapdrillchart.html");
        }

        public PipeTapChartList(bool taper)
        {
            if (taper)
                GetBaseList("DrillCharts.Charts.straightpipetapdrillchart.html");
            else
                GetBaseList("DrillCharts.Charts.taperpipetapdrillchart.html");
        }

        public PipeTapChartList(string docName)
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

            List<PipeTapChartRow> list = this;

            int index = 0;

            foreach (XElement de in doc.Root.Elements())
            {
                PipeTapChartRow row = new PipeTapChartRow();

                row.index = index;

                int j = 0;
                foreach (XElement c in de.Elements())
                {
                    string strValue = c.Value;
                    switch (j)
                    {
                        case 0: row.size = strValue; break;
                        case 1: row.drill = strValue; break;
                        case 2: row.inches = strValue; break;
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
