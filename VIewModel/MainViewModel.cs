namespace ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        IUiService UiService;

        public CustomerDetailsVM CustomerDetailsVM { get; private set; } = new CustomerDetailsVM();
        public OrderDetailsVM OrderDetailsVM { get; private set; } = new OrderDetailsVM();

        private string someValue = "Rohan Deore";

        public string SomeValue
        {
            get
            {
                return someValue;
            }
            set
            {
                if (value != someValue)
                {
                    someValue = value;
                }

                OnPropertyChanged("SomeValue");
            }
        }
    }
}
