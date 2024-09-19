using System.Windows;
using ViewModel;

namespace OrderProcessingWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IUiService UiService { get; } = new UIService();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(UiService);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Check if user is allowed to run this application
            lblStatusBar.Text = "Checking..";
        }
    }
}