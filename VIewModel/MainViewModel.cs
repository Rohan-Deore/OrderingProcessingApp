namespace ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        IUiService UiService;

        public CustomerDetailsVM CustomerDetailsVM { get; private set; } = new CustomerDetailsVM();
        public OrderDetailsVM OrderDetailsVM { get; private set; } = new OrderDetailsVM();

        public MainViewModel(IUiService uiService)
        {
            UiService = uiService;
            CustomerDetailsVM = new CustomerDetailsVM(uiService);
            OrderDetailsVM = new OrderDetailsVM(uiService);
        }
    }
}
