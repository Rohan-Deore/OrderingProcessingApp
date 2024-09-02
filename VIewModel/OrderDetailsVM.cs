using System.Collections.ObjectModel;
using ViewModel.Commands;

namespace ViewModel
{
    public class Order
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

        private AddProductCommand addProductCommand;
        public AddProductCommand AddProductCommand 
        {
            get
            {
                if (addProductCommand == null)
                {
                    addProductCommand = new AddProductCommand();
                }

                return addProductCommand;
            }
        }

        private RemoveProductCommand removeProductCommand;

        public RemoveProductCommand RemoveProductCommand
        { 
            get
            {
                if (removeProductCommand == null)
                {
                    removeProductCommand = new RemoveProductCommand();
                }

                return removeProductCommand;
            }
        }

        private IUiService uiService;

        public OrderDetailsVM(IUiService service) 
        {
            orders.Add(new Order { PartID = 1, PartName = "Machine 1" });
            orders.Add(new Order { PartID = 2, PartName = "Machine 2" });
            orders.Add(new Order { PartID = 3, PartName = "Machine 3" });
            orders.Add(new Order { PartID = 4, PartName = "Machine 4" });

            uiService = service;
        }
    }
}