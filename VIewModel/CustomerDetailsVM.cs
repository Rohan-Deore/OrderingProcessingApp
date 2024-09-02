namespace ViewModel
{
    public class CustomerDetailsVM : ViewModelBase
    {
        public string TabName { get; private set; } = "Customer details";
        
        private string customerName = "Enter customer name";

        public string CustomerName 
        {
            get
            {
                return customerName;
            }
            set
            {
                if (customerName != value)
                {
                    customerName = value;
                    OnPropertyChanged(nameof(CustomerName));
                }
            }
        }

        private string customerLocation = string.Empty;

        public string CustomerLocation
        {
            get
            {
                return customerLocation;
            }
            set
            {
                if (customerLocation != value)
                {
                    customerLocation = value;
                    OnPropertyChanged(nameof(CustomerLocation));
                }
            }
        }

        private DateTime orderDate = DateTime.Today;

        public DateTime OrderDate
        {
            get 
            { 
                return orderDate; 
            }
            set 
            {
                if (orderDate != value)
                {
                    orderDate = value;
                    OnPropertyChanged(nameof(OrderDate));
                }
            }
        }

        private DateTime deliveryDate = DateTime.Today;

        public DateTime DeliveryDate
        {
            get 
            { 
                return deliveryDate; 
            }
            set 
            {
                if (orderDate != value)
                {
                    orderDate = value;
                    OnPropertyChanged(nameof(DeliveryDate));
                }
            }
        }
    }
}
