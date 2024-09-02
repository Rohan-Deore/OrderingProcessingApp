using System.Windows.Controls;
using ViewModel;

namespace OrderProcessingWPF
{
    /// <summary>
    /// Interaction logic for CustomerDetails.xaml
    /// </summary>
    public partial class CustomerDetails : UserControl
    {
        public CustomerDetails()
        {
            InitializeComponent();
            DataContext = new CustomerDetailsVM();
        }
    }
}
