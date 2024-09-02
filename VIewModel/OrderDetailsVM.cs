using System.Collections.ObjectModel;

namespace ViewModel
{
    public class Order : ViewModelBase
    {
        private string partName = string.Empty;
        public string PartName 
        {
            get
            { 
                return partName;
            }
            set
            {
                if (partName != value)
                {
                    partName = value;
                    OnPropertyChanged(nameof(PartName));
                }
            }
        }

        private int partID;

        public int PartID 
        {
            get
            { 
                return partID;
            }

            set
            {
                if (partID != value)
                {
                    partID = value;
                    OnPropertyChanged(nameof(PartID));
                }
            }
        }

    }

    public class OrderDetailsVM : ViewModelBase
    {
        public string TabName { get; private set; } = "Order details";

        private ObservableCollection<Order> orders = new ObservableCollection<Order>();
        public ObservableCollection<Order> Orders
        {
            get
            {
                return orders;
            }
            set
            {
                orders = value;
                OnPropertyChanged(nameof(Orders));
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

        public OrderDetailsVM() 
        {
            orders.Add(new Order { PartID = 1, PartName = "Machine 1" });
            orders.Add(new Order { PartID = 2, PartName = "Machine 2" });
            orders.Add(new Order { PartID = 3, PartName = "Machine 3" });
            orders.Add(new Order { PartID = 4, PartName = "Machine 4" });
        }
    }
}