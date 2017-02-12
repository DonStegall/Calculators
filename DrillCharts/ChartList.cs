using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

using System.Reflection;
using System.Windows;
using System.Diagnostics;

namespace DrillCharts
{
    public class ChartList : List<ChartRow>
    {
        //private List<ChartRow> list = null;

        public ChartList()
        {
            GetBaseList();
        }

        private Stream getEmbeddedStream(string strName)
        {
            string[] sa = this.GetType().GetTypeInfo().Assembly.GetManifestResourceNames();
            foreach (var s in sa)
                Debug.WriteLine(s);

            return (this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream(strName));
        }

        //public bool HasList
        //{
        //    get { return list != null; }
        //}

        //public List<ChartRow> Items
        //{
        //    get { return (list); }
        //}

        public bool GetBaseList()
        {
            XDocument doc = null;

            doc = XDocument.Parse((new StreamReader(getEmbeddedStream("DrillCharts.Charts.drillchart.html")).ReadToEnd()));

            //list = new List<ChartRow>();
            List<ChartRow> list = this;

            foreach (XElement de in doc.Root.Elements())
            {
                string rowtype = "";
                string size = "";
                string inches = "";
                string millimeters = "";

                int j = 0;
                foreach (XElement c in de.Elements())
                {
                    string strValue = c.Value;
                    switch (j)
                    {
                        case 0: rowtype = strValue; break;
                        case 1: size = strValue; break;
                        case 2: inches = strValue; break;
                        case 3: millimeters = strValue; break;
                    }
                    j++;
                }
                ChartRow row = new ChartRow();
                row.rowtype = rowtype;
                row.size = size;
                row.inches = inches;
                row.millimeters = millimeters;
                list.Add(row);
            }

            return (true);
        }
    }
}
