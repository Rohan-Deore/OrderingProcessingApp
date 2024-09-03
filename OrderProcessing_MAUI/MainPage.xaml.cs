using ViewModel;

namespace OrderProcessing_MAUI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public IUiService UiService { get; } = new UIService();

        public MainPage()
        {
            InitializeComponent();
            var vm = new MainViewModel(UiService);
            Title = vm.CustomerDetailsVM.TabName;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;
        }

        private void Entry_Completed(object sender, EventArgs e)
        {

        }
    }

}
