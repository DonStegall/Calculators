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
    public sealed partial class TapMetricChartPage : Page
    {
        int fontSize = 14;
        FontFamily fontFamily = new FontFamily("Segoe UI Light");

        public TapMetricChartPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            currentView.BackRequested += CurrentView_BackRequested;

            this.txtPageName.Text = "Tap Drills for Metric Sizes";

            Grid gr = gridRows;
            Grid gh = gridHdr;
            Grid gt = gridTop;
            int gridIndex = 0;

            SolidColorBrush blackBrush = new SolidColorBrush(Color.FromArgb(0xff, 0x00, 0x00, 0x00));
            SolidColorBrush whiteBrush = new SolidColorBrush(Color.FromArgb(0xff, 0xff, 0xff, 0xff));
            SolidColorBrush lightGrayBrush = new SolidColorBrush(Color.FromArgb(0xff, 0xc0, 0xc0, 0xc0));
            SolidColorBrush greenBrush = new SolidColorBrush(Color.FromArgb(0xff, 0x00, 0x80, 0x00));
            SolidColorBrush blueBrush = new SolidColorBrush(Color.FromArgb(0xff, 0x00, 0x00, 0xff));

            SolidColorBrush GhostWhite = new SolidColorBrush(Color.FromArgb(0xff, 0xf0, 0xf0, 0xff));

            gt.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(44, GridUnitType.Pixel) });
            gh.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(44, GridUnitType.Pixel) });

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
            ColumnDefinition col10 = new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) };
            col10.Width = new GridLength(1, GridUnitType.Star);
            gr.ColumnDefinitions.Add(col10);

            ColumnDefinition col1Top = new ColumnDefinition();
            col1Top.Width = new GridLength(100, GridUnitType.Pixel);
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
            ColumnDefinition col6Top = new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) };
            col6Top.Width = new GridLength(1, GridUnitType.Star);
            gt.ColumnDefinitions.Add(col6Top);


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
            ColumnDefinition col10Hdr = new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) };
            col10Hdr.Width = new GridLength(1, GridUnitType.Star);
            gh.ColumnDefinitions.Add(col10Hdr);

            TapMetricChartList baselist = new TapMetricChartList();

            List<TapMetricChartRow> list = baselist;

            SetTopHeaderColumn(gt, 0, "", blackBrush, lightGrayBrush);
            SetTopHeaderColumn(gt, 1, "75% Thread\nMedium Material", blackBrush, lightGrayBrush);
            SetTopHeaderColumn(gt, 2, "50% Thread\nHard Material", blackBrush, lightGrayBrush);
            SetTopHeaderColumn(gt, 3, "Clearance\nClose Fit", blackBrush, lightGrayBrush);
            SetTopHeaderColumn(gt, 4, "Clearance\nFree Fit", blackBrush, lightGrayBrush);
            SetTopHeaderColumn(gt, 5, "", blackBrush, lightGrayBrush);

            SetHeaderColumn(gh, 0, "", blackBrush, lightGrayBrush);
            SetHeaderColumn(gh, 1, "Size\n(mm)", blackBrush, lightGrayBrush);
            SetHeaderColumn(gh, 2, "Drill Size\n(mm)", blackBrush, lightGrayBrush);
            SetHeaderColumn(gh, 3, "Closest\nUS Drill", blackBrush, lightGrayBrush);
            SetHeaderColumn(gh, 4, "Drill Size\n(mm)", blackBrush, lightGrayBrush);
            SetHeaderColumn(gh, 5, "Closest\nUS Drill", blackBrush, lightGrayBrush);
            SetHeaderColumn(gh, 6, "Drill Size\n(mm)", blackBrush, lightGrayBrush);
            SetHeaderColumn(gh, 7, "Closest\nUS Drill", blackBrush, lightGrayBrush);
            SetHeaderColumn(gh, 8, "Drill Size\n(mm)", blackBrush, lightGrayBrush);
            SetHeaderColumn(gh, 9, "Closest\nUS Drill", blackBrush, lightGrayBrush);
            SetHeaderColumn(gh, 10, "", blackBrush, lightGrayBrush);

            for (int i = 0; (i < list.Count); i++)
            {
                Brush fg = blackBrush;
                Brush bg = whiteBrush;

                if ((i % 2) != 0)
                    bg = GhostWhite;

                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(24, GridUnitType.Pixel);
                gr.RowDefinitions.Add(row);

                fg = blackBrush;

                SetColumn(gr, gridIndex, 0, "", fg, bg);
                SetColumn(gr, gridIndex, 1, list[i].name, fg, bg);
                SetColumn(gr, gridIndex, 2, list[i].mm75, fg, bg);
                SetColumn(gr, gridIndex, 3, list[i].us75, fg, bg);
                SetColumn(gr, gridIndex, 4, list[i].mm50, fg, bg);
                SetColumn(gr, gridIndex, 5, list[i].us50, fg, bg);
                SetColumn(gr, gridIndex, 6, list[i].closemm, fg, bg);
                SetColumn(gr, gridIndex, 7, list[i].closeus, fg, bg);
                SetColumn(gr, gridIndex, 8, list[i].freemm, fg, bg);
                SetColumn(gr, gridIndex, 9, list[i].freeus, fg, bg);
                SetColumn(gr, gridIndex, 10, "", fg, bg);

                gridIndex++;
            }

        }

        private void SetTopHeaderColumn(Grid gt, int col, string text, SolidColorBrush blackBrush, SolidColorBrush lightGrayBrush)
        {
            Border b = new Border();
            TextBlock tb = null;

            b.Background = lightGrayBrush;
            tb = new TextBlock();
            tb.Text = text;
            tb.FontSize = fontSize;
            tb.FontFamily = fontFamily;
            tb.VerticalAlignment = VerticalAlignment.Center;
            tb.HorizontalAlignment = HorizontalAlignment.Center;
            tb.TextWrapping = TextWrapping.Wrap;
            tb.Foreground = blackBrush;
            Grid.SetColumn(b, col);
            Grid.SetRow(b, 0);
            b.Child = tb;
            gt.Children.Add(b);
        }

        private void SetHeaderColumn(Grid gh, int col, string text, SolidColorBrush blackBrush, SolidColorBrush lightGrayBrush)
        {
            Border b = new Border();
            TextBlock tb = null;

            b = new Border();
            b.Background = lightGrayBrush;
            tb = new TextBlock();
            tb.Text = text;
            tb.FontSize = fontSize;
            tb.FontFamily = fontFamily;
            tb.VerticalAlignment = VerticalAlignment.Center;
            tb.HorizontalAlignment = HorizontalAlignment.Left;
            tb.TextWrapping = TextWrapping.Wrap;
            tb.Foreground = blackBrush;
            Grid.SetColumn(b, col);
            Grid.SetRow(b, 0);
            b.Child = tb;
            gh.Children.Add(b);
        }

        private void SetColumn(Grid gr, int gridIndex, int col, string text, Brush fg, Brush bg)
        {
            Border b = null;
            TextBlock tb = null;

            b = new Border();
            b.BorderBrush = bg;
            b.Background = bg;
            tb = new TextBlock();
            tb.Text = text;
            tb.FontSize = fontSize;
            tb.FontFamily = fontFamily;
            tb.VerticalAlignment = VerticalAlignment.Center;
            tb.Foreground = fg;
            Grid.SetColumn(b, col);
            Grid.SetRow(b, gridIndex);
            b.Child = tb;
            gr.Children.Add(b);
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
    }
}
