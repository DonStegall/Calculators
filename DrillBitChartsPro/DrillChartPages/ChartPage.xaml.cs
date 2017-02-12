using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Core;

using DrillCharts;

namespace DrillBitChartsPro
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChartPage : Page
    {
        string param = "all";

        public ChartPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            currentView.BackRequested += CurrentView_BackRequested;

            param = (string)e.Parameter;

            if (param == "all")
            {
                this.txtPageName.Text = "All Size Types";
            }
            else if (param == "number")
            {
                this.txtPageName.Text = "Number";
            }
            else if (param == "letter")
            {
                this.txtPageName.Text = "Letter";
            }
            else if (param == "metric")
            {
                this.txtPageName.Text = "Metric";
            }
            else if (param == "fractional")
            {
                this.txtPageName.Text = "Fractional Inch";
            }
            else if (param == "named")
            {
                this.txtPageName.Text = "Number / Letter";
            }
            else
            {
                this.txtPageName.Text = "Drills";
            };

            Grid g = grid;
            Grid gh = gridHdr;
            int gridIndex = 0;
            Border b = null;
            TextBlock tb = null;

            SolidColorBrush blackBrush = new SolidColorBrush(Color.FromArgb(0xff, 0x00, 0x00, 0x00));
            SolidColorBrush whiteBrush = new SolidColorBrush(Color.FromArgb(0xff, 0xff, 0xff, 0xff));
            SolidColorBrush lightGrayBrush = new SolidColorBrush(Color.FromArgb(0xff, 0xc0, 0xc0, 0xc0));
            SolidColorBrush greenBrush = new SolidColorBrush(Color.FromArgb(0xff, 0x00, 0x80, 0x00));
            SolidColorBrush blueBrush = new SolidColorBrush(Color.FromArgb(0xff, 0x00, 0x00, 0xff));


            SolidColorBrush GhostWhite = new SolidColorBrush(Color.FromArgb(0xff, 0xf0, 0xf0, 0xff));

            gh.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(20, GridUnitType.Pixel) });

            ColumnDefinition leftMargin = new ColumnDefinition();
            leftMargin.Width = new GridLength(20, GridUnitType.Pixel);
            g.ColumnDefinitions.Add(leftMargin);
            ColumnDefinition col1 = new ColumnDefinition();
            col1.Width = new GridLength(150, GridUnitType.Pixel);
            g.ColumnDefinitions.Add(col1);
            ColumnDefinition col2 = new ColumnDefinition();
            col2.Width = new GridLength(150, GridUnitType.Pixel);
            g.ColumnDefinitions.Add(col2);
            ColumnDefinition col3 = new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star), MinWidth = 500 };
            col3.Width = new GridLength(100, GridUnitType.Star);
            g.ColumnDefinitions.Add(col3);

            //g.ShowGridLines = false;

            ColumnDefinition leftMarginHdr = new ColumnDefinition();
            leftMarginHdr.Width = new GridLength(20, GridUnitType.Pixel);
            gh.ColumnDefinitions.Add(leftMarginHdr);
            ColumnDefinition col1Hdr = new ColumnDefinition();
            col1Hdr.Width = new GridLength(150, GridUnitType.Pixel);
            gh.ColumnDefinitions.Add(col1Hdr);
            ColumnDefinition col2Hdr = new ColumnDefinition();
            col2Hdr.Width = new GridLength(150, GridUnitType.Pixel);
            gh.ColumnDefinitions.Add(col2Hdr);
            ColumnDefinition col3Hdr = new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star), MinWidth = 500 };
            col3Hdr.Width = new GridLength(1, GridUnitType.Star);
            gh.ColumnDefinitions.Add(col3Hdr);

            //gh.Height = new GridLength(40, GridUnitType.Pixel);
            //DFS gh.MinHeight = 40.0;
            //gh.ShowGridLines = false;

            string typeName = "Size";

            DrillChartList baselist = new DrillChartList();

            //baselist.GetBaseList();

            List<DrillChartRow> list = null;

            if (param == "all")
            {
                list = (from p in baselist select p).ToList();
                typeName = "Size";
            }
            else if (param == "number")
            {
                list = (from p in baselist where p.rowtype == "std4" select p).ToList();
                typeName = "Number";
            }
            else if (param == "letter")
            {
                list = (from p in baselist where p.rowtype == "std3" select p).ToList();
                typeName = "Letter";
            }
            else if (param == "metric")
            {
                list = (from p in baselist where p.rowtype == "std2" select p).ToList();
                typeName = "Metric";
            }
            else if (param == "fractional")
            {
                list = (from p in baselist where p.rowtype == "std1" select p).ToList();
                typeName = "Fractional (in)";
            }
            else if (param == "named")
            {
                list = (from p in baselist where (p.rowtype == "std3") || (p.rowtype == "std4") select p).ToList();
                typeName = "Name";
            };


            b = new Border();
            b.Background = lightGrayBrush;
            tb = new TextBlock();
            tb.Text = "";
            tb.Foreground = blackBrush;
            Grid.SetColumn(b, 0);
            Grid.SetRow(b, 0);
            b.Child = tb;
            gh.Children.Add(b);

            b = new Border();
            b.Background = lightGrayBrush;
            tb = new TextBlock();
            tb.Text = typeName;
            tb.Foreground = blackBrush;
            Grid.SetColumn(b, 1);
            Grid.SetRow(b, 0);
            b.Child = tb;
            gh.Children.Add(b);

            b = new Border();
            b.Background = lightGrayBrush;
            tb = new TextBlock();
            tb.Text = "Decimal (in)";
            tb.Foreground = blackBrush;
            Grid.SetColumn(b, 2);
            Grid.SetRow(b, 0);
            b.Child = tb;
            gh.Children.Add(b);

            b = new Border();
            b.Background = lightGrayBrush;
            tb = new TextBlock();
            tb.Text = "Metric (mm)";
            tb.Foreground = blackBrush;
            Grid.SetColumn(b, 3);
            Grid.SetRow(b, 0);
            b.Child = tb;
            gh.Children.Add(b);


            for (int i = 0; (i < list.Count); i++)
            {
                Brush fg = blackBrush;
                Brush bg = whiteBrush;

                if ((i % 2) != 0)
                    bg = GhostWhite;

                g.RowDefinitions.Add(new RowDefinition());

                if (list[i].rowtype.Equals("std1") && (param == "all"))
                    fg = blueBrush;

                else if (list[i].rowtype.Equals("std4") && (param == "all"))
                    fg = greenBrush;

                else
                    fg = blackBrush;

                b = new Border();
                b.BorderBrush = bg;
                b.Background = bg;
                tb = new TextBlock();
                tb.Text = "";
                tb.Foreground = fg;
                Grid.SetColumn(tb, 0);
                Grid.SetRow(b, gridIndex);
                b.Child = tb;
                grid.Children.Add(b);

                b = new Border();
                b.BorderBrush = bg;
                b.Background = bg;
                tb = new TextBlock();
                tb.Text = list[i].size;
                tb.Foreground = fg;
                //tb.Background = bg;
                Grid.SetColumn(b, 1);
                Grid.SetRow(b, gridIndex);
                b.Child = tb;
                grid.Children.Add(b);

                b = new Border();
                b.BorderBrush = bg;
                b.Background = bg;
                tb = new TextBlock();
                tb.Text = list[i].inches;
                tb.Foreground = fg;
                //tb.Background = bg;
                Grid.SetColumn(b, 2);
                Grid.SetRow(b, gridIndex);
                b.Child = tb;
                grid.Children.Add(b);

                b = new Border();
                b.BorderBrush = bg;
                b.Background = bg;
                tb = new TextBlock();
                tb.Text = list[i].millimeters;
                tb.Foreground = fg;
                Grid.SetColumn(b, 3);
                Grid.SetRow(b, gridIndex);
                b.Child = tb;
                grid.Children.Add(b);

                gridIndex++;
            }



        }

        private void CurrentView_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            var currentView = SystemNavigationManager.GetForCurrentView();

            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;

            currentView.BackRequested -= CurrentView_BackRequested;
        }


    }
}
