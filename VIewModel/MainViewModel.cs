namespace ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        IUiService UiService;

        public CustomerDetailsVM CustomerDetailsVM { get; private set; }
        public OrderDetailsVM OrderDetailsVM { get; private set; }

        public MainViewModel(IUiService uiService)
        {
            UiService = uiService;
            CustomerDetailsVM = new CustomerDetailsVM();
            OrderDetailsVM = new OrderDetailsVM();
            CustomerDetailsVM.SetUIService(uiService);
            OrderDetailsVM.SetUIService(uiService);

        }
    }
}
