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
using System.Diagnostics;

using DrillCharts;


namespace DrillBitChartsPro
{
    public sealed partial class TapUSNextChartPage : Page
    {
        string param = "all";

        public TapUSNextChartPage()
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

            this.txtPageName.Text = "Next Tap Drills for U.S. Sizes";

            Grid gr = gridRows;
            Grid gh = gridHdr;
            Grid gt = gridTop;
            int gridIndex = 0;
            Border b = null;
            TextBlock tb = null;

            SolidColorBrush blackBrush = new SolidColorBrush(Color.FromArgb(0xff, 0x00, 0x00, 0x00));
            SolidColorBrush whiteBrush = new SolidColorBrush(Color.FromArgb(0xff, 0xff, 0xff, 0xff));
            SolidColorBrush lightGrayBrush = new SolidColorBrush(Color.FromArgb(0xff, 0xc0, 0xc0, 0xc0));
            SolidColorBrush greenBrush = new SolidColorBrush(Color.FromArgb(0xff, 0x00, 0x80, 0x00));
            SolidColorBrush blueBrush = new SolidColorBrush(Color.FromArgb(0xff, 0x00, 0x00, 0xff));


            SolidColorBrush GhostWhite = new SolidColorBrush(Color.FromArgb(0xff, 0xf0, 0xf0, 0xff));

            gt.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(44, GridUnitType.Pixel) });
            gh.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(22, GridUnitType.Pixel) });
            //gh.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(20, GridUnitType.Pixel) });

            ColumnDefinition leftMargin = new ColumnDefinition();
            leftMargin.Width = new GridLength(20, GridUnitType.Pixel);
            gr.ColumnDefinitions.Add(leftMargin);
            ColumnDefinition col1 = new ColumnDefinition();
            col1.Width = new GridLength(100, GridUnitType.Pixel);
            gr.ColumnDefinitions.Add(col1);
            ColumnDefinition col2 = new ColumnDefinition();
            col2.Width = new GridLength(100, GridUnitType.Pixel);
            gr.ColumnDefinitions.Add(col2);
            ColumnDefinition col3 = new ColumnDefinition();
            col3.Width = new GridLength(100, GridUnitType.Pixel);
            gr.ColumnDefinitions.Add(col3);
            ColumnDefinition col4 = new ColumnDefinition();
            col4.Width = new GridLength(100, GridUnitType.Pixel);
            gr.ColumnDefinitions.Add(col4);
            ColumnDefinition col5 = new ColumnDefinition();
            col5.Width = new GridLength(100, GridUnitType.Pixel);
            gr.ColumnDefinitions.Add(col5);
            ColumnDefinition col6 = new ColumnDefinition();
            col6.Width = new GridLength(100, GridUnitType.Pixel);
            gr.ColumnDefinitions.Add(col6);
            ColumnDefinition col7 = new ColumnDefinition();
            col7.Width = new GridLength(100, GridUnitType.Pixel);
            gr.ColumnDefinitions.Add(col7);
            ColumnDefinition col8 = new ColumnDefinition();
            col8.Width = new GridLength(100, GridUnitType.Pixel);
            gr.ColumnDefinitions.Add(col8);
            ColumnDefinition col9 = new ColumnDefinition();
            col9.Width = new GridLength(100, GridUnitType.Pixel);
            gr.ColumnDefinitions.Add(col9);
            ColumnDefinition col10 = new ColumnDefinition();
            col10.Width = new GridLength(100, GridUnitType.Pixel);
            gr.ColumnDefinitions.Add(col10);
            ColumnDefinition col11 = new ColumnDefinition();
            col11.Width = new GridLength(100, GridUnitType.Pixel);
            gr.ColumnDefinitions.Add(col11);
            ColumnDefinition col12 = new ColumnDefinition();
            col12.Width = new GridLength(100, GridUnitType.Pixel);
            gr.ColumnDefinitions.Add(col12);
            ColumnDefinition col13 = new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) };
            col13.Width = new GridLength(1, GridUnitType.Star);
            gr.ColumnDefinitions.Add(col13);

            ColumnDefinition col1Top = new ColumnDefinition();
            col1Top.Width = new GridLength(200, GridUnitType.Pixel);
            gt.ColumnDefinitions.Add(col1Top);
            ColumnDefinition col2Top = new ColumnDefinition();
            col2Top.Width = new GridLength(200, GridUnitType.Pixel);
            gt.ColumnDefinitions.Add(col2Top);
            ColumnDefinition col3Top = new ColumnDefinition();
            col3Top.Width = new GridLength(200, GridUnitType.Pixel);
            gt.ColumnDefinitions.Add(col3Top);
            ColumnDefinition col4Top = new ColumnDefinition();
            col4Top.Width = new GridLength(200, GridUnitType.Pixel);
            gt.ColumnDefinitions.Add(col4Top);
            ColumnDefinition col5Top = new ColumnDefinition();
            col5Top.Width = new GridLength(200, GridUnitType.Pixel);
            gt.ColumnDefinitions.Add(col5Top);
            ColumnDefinition col6Top = new ColumnDefinition();
            col6Top.Width = new GridLength(200, GridUnitType.Pixel);
            gt.ColumnDefinitions.Add(col6Top);
            ColumnDefinition col7Top = new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) };
            col7Top.Width = new GridLength(1, GridUnitType.Star);
            gt.ColumnDefinitions.Add(col7Top);


            ColumnDefinition leftMarginHdr = new ColumnDefinition();
            leftMarginHdr.Width = new GridLength(20, GridUnitType.Pixel);
            gh.ColumnDefinitions.Add(leftMarginHdr);
            ColumnDefinition col1Hdr = new ColumnDefinition();
            col1Hdr.Width = new GridLength(100, GridUnitType.Pixel);
            gh.ColumnDefinitions.Add(col1Hdr);
            ColumnDefinition col2Hdr = new ColumnDefinition();
            col2Hdr.Width = new GridLength(100, GridUnitType.Pixel);
            gh.ColumnDefinitions.Add(col2Hdr);
            ColumnDefinition col3Hdr = new ColumnDefinition();
            col3Hdr.Width = new GridLength(100, GridUnitType.Pixel);
            gh.ColumnDefinitions.Add(col3Hdr);
            ColumnDefinition col4Hdr = new ColumnDefinition();
            col4Hdr.Width = new GridLength(100, GridUnitType.Pixel);
            gh.ColumnDefinitions.Add(col4Hdr);
            ColumnDefinition col5Hdr = new ColumnDefinition();
            col5Hdr.Width = new GridLength(100, GridUnitType.Pixel);
            gh.ColumnDefinitions.Add(col5Hdr);
            ColumnDefinition col6Hdr = new ColumnDefinition();
            col6Hdr.Width = new GridLength(100, GridUnitType.Pixel);
            gh.ColumnDefinitions.Add(col6Hdr);
            ColumnDefinition col7Hdr = new ColumnDefinition();
            col7Hdr.Width = new GridLength(100, GridUnitType.Pixel);
            gh.ColumnDefinitions.Add(col7Hdr);
            ColumnDefinition col8Hdr = new ColumnDefinition();
            col8Hdr.Width = new GridLength(100, GridUnitType.Pixel);
            gh.ColumnDefinitions.Add(col8Hdr);
            ColumnDefinition col9Hdr = new ColumnDefinition();
            col9Hdr.Width = new GridLength(100, GridUnitType.Pixel);
            gh.ColumnDefinitions.Add(col9Hdr);
            ColumnDefinition col10Hdr = new ColumnDefinition();
            col10Hdr.Width = new GridLength(100, GridUnitType.Pixel);
            gh.ColumnDefinitions.Add(col10Hdr);
            ColumnDefinition col11Hdr = new ColumnDefinition();
            col11Hdr.Width = new GridLength(100, GridUnitType.Pixel);
            gh.ColumnDefinitions.Add(col11Hdr);
            ColumnDefinition col12Hdr = new ColumnDefinition();
            col12Hdr.Width = new GridLength(100, GridUnitType.Pixel);
            gh.ColumnDefinitions.Add(col12Hdr);
            ColumnDefinition col13Hdr = new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) };
            col13Hdr.Width = new GridLength(1, GridUnitType.Star);
            gh.ColumnDefinitions.Add(col13Hdr);

            //gh.Height = new GridLength(40, GridUnitType.Pixel);
            //DFS gh.MinHeight = 40.0;
            //gh.ShowGridLines = false;

            TapUSChartList baselist = new TapUSChartList();

            List<TapUSChartRow> list = baselist;

            b = new Border();
            b.Background = lightGrayBrush;
            tb = new TextBlock();
            tb.Text = "";
            tb.Foreground = blackBrush;
            Grid.SetColumn(b, 0);
            Grid.SetRow(b, 0);
            b.Child = tb;
            gt.Children.Add(b);

            b = new Border();
            b.Background = lightGrayBrush;
            tb = new TextBlock();
            tb.Text = "100% Thread\nSoft Material";
            tb.HorizontalAlignment = HorizontalAlignment.Center;
            tb.TextWrapping = TextWrapping.Wrap;
            tb.Foreground = blackBrush;
            Grid.SetColumn(b, 1);
            Grid.SetRow(b, 0);
            b.Child = tb;
            gt.Children.Add(b);

            b = new Border();
            b.Background = lightGrayBrush;
            tb = new TextBlock();
            tb.Text = "75% Thread\nMedium Material";
            tb.HorizontalAlignment = HorizontalAlignment.Center;
            tb.TextWrapping = TextWrapping.Wrap;
            tb.Foreground = blackBrush;
            Grid.SetColumn(b, 2);
            Grid.SetRow(b, 0);
            b.Child = tb;
            gt.Children.Add(b);

            b = new Border();
            b.Background = lightGrayBrush;
            tb = new TextBlock();
            tb.Text = "50% Thread\nHard Material";
            tb.HorizontalAlignment = HorizontalAlignment.Center;
            tb.TextWrapping = TextWrapping.Wrap;
            tb.Foreground = blackBrush;
            Grid.SetColumn(b, 3);
            Grid.SetRow(b, 0);
            b.Child = tb;
            gt.Children.Add(b);

            b = new Border();
            b.Background = lightGrayBrush;
            tb = new TextBlock();
            tb.Text = "Clearance\nClose Fit";
            tb.HorizontalAlignment = HorizontalAlignment.Center;
            tb.TextWrapping = TextWrapping.Wrap;
            tb.Foreground = blackBrush;
            Grid.SetColumn(b, 4);
            Grid.SetRow(b, 0);
            b.Child = tb;
            gt.Children.Add(b);

            b = new Border();
            b.Background = lightGrayBrush;
            tb = new TextBlock();
            tb.Text = "Clearance\nFree Fit";
            tb.HorizontalAlignment = HorizontalAlignment.Center;
            tb.TextWrapping = TextWrapping.Wrap;
            tb.Foreground = blackBrush;
            Grid.SetColumn(b, 5);
            Grid.SetRow(b, 0);
            b.Child = tb;
            gt.Children.Add(b);

            b = new Border();
            b.Background = lightGrayBrush;
            tb = new TextBlock();
            tb.Text = "";
            tb.HorizontalAlignment = HorizontalAlignment.Center;
            tb.TextWrapping = TextWrapping.Wrap;
            tb.Foreground = blackBrush;
            Grid.SetColumn(b, 6);
            Grid.SetRow(b, 0);
            b.Child = tb;
            gt.Children.Add(b);



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
            tb.Text = "Size";
            tb.Foreground = blackBrush;
            Grid.SetColumn(b, 1);
            Grid.SetRow(b, 0);
            b.Child = tb;
            gh.Children.Add(b);

            b = new Border();
            b.Background = lightGrayBrush;
            tb = new TextBlock();
            tb.Text = "Diameter";
            tb.Foreground = blackBrush;
            Grid.SetColumn(b, 2);
            Grid.SetRow(b, 0);
            b.Child = tb;
            gh.Children.Add(b);

            b = new Border();
            b.Background = lightGrayBrush;
            tb = new TextBlock();
            tb.Text = "Drill";
            tb.Foreground = blackBrush;
            Grid.SetColumn(b, 3);
            Grid.SetRow(b, 0);
            b.Child = tb;
            gh.Children.Add(b);

            b = new Border();
            b.Background = lightGrayBrush;
            tb = new TextBlock();
            tb.Text = "Decimal";
            tb.Foreground = blackBrush;
            Grid.SetColumn(b, 4);
            Grid.SetRow(b, 0);
            b.Child = tb;
            gh.Children.Add(b);

            b = new Border();
            b.Background = lightGrayBrush;
            tb = new TextBlock();
            tb.Text = "Drill";
            tb.Foreground = blackBrush;
            Grid.SetColumn(b, 5);
            Grid.SetRow(b, 0);
            b.Child = tb;
            gh.Children.Add(b);

            b = new Border();
            b.Background = lightGrayBrush;
            tb = new TextBlock();
            tb.Text = "Decimal";
            tb.Foreground = blackBrush;
            Grid.SetColumn(b, 6);
            Grid.SetRow(b, 0);
            b.Child = tb;
            gh.Children.Add(b);

            b = new Border();
            b.Background = lightGrayBrush;
            tb = new TextBlock();
            tb.Text = "Drill";
            tb.Foreground = blackBrush;
            Grid.SetColumn(b, 7);
            Grid.SetRow(b, 0);
            b.Child = tb;
            gh.Children.Add(b);

            b = new Border();
            b.Background = lightGrayBrush;
            tb = new TextBlock();
            tb.Text = "Decimal";
            tb.Foreground = blackBrush;
            Grid.SetColumn(b, 8);
            Grid.SetRow(b, 0);
            b.Child = tb;
            gh.Children.Add(b);

            b = new Border();
            b.Background = lightGrayBrush;
            tb = new TextBlock();
            tb.Text = "Drill";
            tb.Foreground = blackBrush;
            Grid.SetColumn(b, 9);
            Grid.SetRow(b, 0);
            b.Child = tb;
            gh.Children.Add(b);

            b = new Border();
            b.Background = lightGrayBrush;
            tb = new TextBlock();
            tb.Text = "Decimal";
            tb.Foreground = blackBrush;
            Grid.SetColumn(b, 10);
            Grid.SetRow(b, 0);
            b.Child = tb;
            gh.Children.Add(b);

            b = new Border();
            b.Background = lightGrayBrush;
            tb = new TextBlock();
            tb.Text = "Drill";
            tb.Foreground = blackBrush;
            Grid.SetColumn(b, 11);
            Grid.SetRow(b, 0);
            b.Child = tb;
            gh.Children.Add(b);

            b = new Border();
            b.Background = lightGrayBrush;
            tb = new TextBlock();
            tb.Text = "Decimal";
            tb.Foreground = blackBrush;
            Grid.SetColumn(b, 12);
            Grid.SetRow(b, 0);
            b.Child = tb;
            gh.Children.Add(b);

            b = new Border();
            b.Background = lightGrayBrush;
            tb = new TextBlock();
            tb.Text = "";
            tb.Foreground = blackBrush;
            Grid.SetColumn(b, 13);
            Grid.SetRow(b, 0);
            b.Child = tb;
            gh.Children.Add(b);

            //OuterScroll.Height = 200;
            //InnerScroll.Height = 700;

            for (int i = 0; (i < list.Count); i++)
            {
                Brush fg = blackBrush;
                Brush bg = whiteBrush;

                if ((i % 2) != 0)
                    bg = GhostWhite;

                gr.RowDefinitions.Add(new RowDefinition());

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
                gr.Children.Add(b);

                b = new Border();
                b.BorderBrush = bg;
                b.Background = bg;
                tb = new TextBlock();
                tb.Text = list[i].name;
                tb.Foreground = fg;
                Grid.SetColumn(b, 1);
                Grid.SetRow(b, gridIndex);
                b.Child = tb;
                gr.Children.Add(b);

                b = new Border();
                b.BorderBrush = bg;
                b.Background = bg;
                tb = new TextBlock();
                tb.Text = list[i].outdia;
                tb.Foreground = fg;
                Grid.SetColumn(b, 2);
                Grid.SetRow(b, gridIndex);
                b.Child = tb;
                gr.Children.Add(b);

                b = new Border();
                b.BorderBrush = bg;
                b.Background = bg;
                tb = new TextBlock();
                tb.Text = list[i].drill100;
                tb.Foreground = fg;
                Grid.SetColumn(b, 3);
                Grid.SetRow(b, gridIndex);
                b.Child = tb;
                gr.Children.Add(b);

                b = new Border();
                b.BorderBrush = bg;
                b.Background = bg;
                tb = new TextBlock();
                tb.Text = list[i].dia100;
                tb.Foreground = fg;
                Grid.SetColumn(b, 4);
                Grid.SetRow(b, gridIndex);
                b.Child = tb;
                gr.Children.Add(b);

                b = new Border();
                b.BorderBrush = bg;
                b.Background = bg;
                tb = new TextBlock();
                tb.Text = list[i].drill75;
                tb.Foreground = fg;
                Grid.SetColumn(b, 5);
                Grid.SetRow(b, gridIndex);
                b.Child = tb;
                gr.Children.Add(b);

                b = new Border();
                b.BorderBrush = bg;
                b.Background = bg;
                tb = new TextBlock();
                tb.Text = list[i].dia75;
                tb.Foreground = fg;
                Grid.SetColumn(b, 6);
                Grid.SetRow(b, gridIndex);
                b.Child = tb;
                gr.Children.Add(b);

                b = new Border();
                b.BorderBrush = bg;
                b.Background = bg;
                tb = new TextBlock();
                tb.Text = list[i].drill50;
                tb.Foreground = fg;
                Grid.SetColumn(b, 7);
                Grid.SetRow(b, gridIndex);
                b.Child = tb;
                gr.Children.Add(b);

                b = new Border();
                b.BorderBrush = bg;
                b.Background = bg;
                tb = new TextBlock();
                tb.Text = list[i].dia50;
                tb.Foreground = fg;
                Grid.SetColumn(b, 8);
                Grid.SetRow(b, gridIndex);
                b.Child = tb;
                gr.Children.Add(b);

                b = new Border();
                b.BorderBrush = bg;
                b.Background = bg;
                tb = new TextBlock();
                tb.Text = list[i].closedrill;
                tb.Foreground = fg;
                Grid.SetColumn(b, 9);
                Grid.SetRow(b, gridIndex);
                b.Child = tb;
                gr.Children.Add(b);

                b = new Border();
                b.BorderBrush = bg;
                b.Background = bg;
                tb = new TextBlock();
                tb.Text = list[i].closedia;
                tb.Foreground = fg;
                Grid.SetColumn(b, 10);
                Grid.SetRow(b, gridIndex);
                b.Child = tb;
                gr.Children.Add(b);

                b = new Border();
                b.BorderBrush = bg;
                b.Background = bg;
                tb = new TextBlock();
                tb.Text = list[i].freedrill;
                tb.Foreground = fg;
                Grid.SetColumn(b, 11);
                Grid.SetRow(b, gridIndex);
                b.Child = tb;
                gr.Children.Add(b);

                b = new Border();
                b.BorderBrush = bg;
                b.Background = bg;
                tb = new TextBlock();
                tb.Text = list[i].freedia;
                tb.Foreground = fg;
                Grid.SetColumn(b, 12);
                Grid.SetRow(b, gridIndex);
                b.Child = tb;
                gr.Children.Add(b);

                b = new Border();
                b.BorderBrush = bg;
                b.Background = bg;
                tb = new TextBlock();
                tb.Text = "";
                tb.Foreground = fg;
                Grid.SetColumn(b, 13);
                Grid.SetRow(b, gridIndex);
                b.Child = tb;
                gr.Children.Add(b);

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

        private void scrollInner_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            scrollInner.Height = scrollOuter.ActualHeight - gridTop.ActualHeight - gridHdr.ActualHeight;
            //InnerScroll.Height = e.NewSize.Height;
        }

        private void LayoutRoot_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //int i = 0;
        }

        private void scrollOuter_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            scrollInner.Height = scrollOuter.ActualHeight - gridTop.ActualHeight - gridHdr.ActualHeight;
            //int i = 0;
        }

        private void scrollInner_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            Debug.WriteLine("ManipulationStarted = " + e.Position.X + "," +e.Position.Y);
        }

        private void scrollInner_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            Debug.WriteLine("ManipulationDelta = " + e.Position.X + "," + e.Position.Y);
        }
    }
}
