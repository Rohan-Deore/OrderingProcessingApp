using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace OrderProcessing_WinUI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        ObservableCollection<string> NavLinks = new ObservableCollection<string>() { "Rohan", "Deore" };

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            //myButton.Content = "Clicked";
        }

        private async void NavLinksList_ItemClick(object sender, ItemClickEventArgs e)
        {
            //MessageDialog msgDlg = new MessageDialog($"Item clicked {e.ClickedItem.ToString()}");
            //await msgDlg.ShowAsync();

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageDialog msgDlg = new MessageDialog("Item clicked");
            //await msgDlg.ShowAsync();
        }
    }
}
