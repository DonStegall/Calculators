using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using DrillBitChartsPro.Data;

namespace DrillBitChartsPro
{
    public sealed partial class MainPage : Page
    {
        List<MenuOption> menu = new List<MenuOption>();

        public MainPage()
        {
            this.InitializeComponent();
            menu.Add(new MenuOption() { Title = "Fractional", Param = "fractional", PageClass = typeof(DrillChartPage) });
            menu.Add(new MenuOption() { Title = "Number/ Letter", Param = "named", PageClass = typeof(DrillChartPage) });
            menu.Add(new MenuOption() { Title = "Number", Param = "number", PageClass = typeof(DrillChartPage) });
            menu.Add(new MenuOption() { Title = "Letter", Param = "letter", PageClass = typeof(DrillChartPage) });
            menu.Add(new MenuOption() { Title = "Metric", Param = "metric", PageClass = typeof(DrillChartPage) });
            menu.Add(new MenuOption() { Title = "All Size Types", Param = "all", PageClass = typeof(DrillChartPage) });
            menu.Add(new MenuOption() { Title = "Tap Drills for U.S. Sizes", Param = "", PageClass = typeof(TapUSChartPage) });
            menu.Add(new MenuOption() { Title = "Tap Drills for Metric Sizes", Param = "", PageClass = typeof(TapMetricChartPage) });
            menu.Add(new MenuOption() { Title = "Straight Pipe Tap Drills - NPS", Param = "straight", PageClass = typeof(PipeTapChartPage) });
            menu.Add(new MenuOption() { Title = "Taper Pipe Tap Drills - NPT", Param = "taper", PageClass = typeof(PipeTapChartPage) });
            menu.Add(new MenuOption() { Title = "Wood Screws for U.S. Sizes", Param = "", PageClass = typeof(WoodscrewUSChartPage) });
            listMenuView.ItemsSource = menu;
        }

        private void listMenuView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Debug.WriteLine("listMenuView_ItemClick = " + e.ToString() + "  " + e.ClickedItem.ToString() );
            MenuOption item = (MenuOption)e.ClickedItem;
            this.Frame.Navigate(item.PageClass, item.Param);
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AboutPage), "");
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HelpPage), "");
        }

        private void VersionHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(VersionHistoryPage), "");
        }

        private void ComingSoonButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ComingSoonPage), "");
        }

    }
}
