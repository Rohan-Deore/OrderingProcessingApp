using CommunityToolkit.Maui.Views;
using ViewModel;

namespace OrderProcessing_MAUI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public IUiService UiService { get; }

        public MainPage()
        {
            InitializeComponent();
            UiService = new UIService(this);
            var vm = new MainViewModel(UiService);
            Title = vm.CustomerDetailsVM.TabName;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            ShowMessage("Test button clicked.");
        }

        public void ShowMessage(string message)
        {
            var popup = new SimplePopup(message);
            this.ShowPopup(popup);
        }
    }
}
