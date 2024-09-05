namespace WebAPI_DB
{
    public class CustomerManager
    {
        private List<Orders> orderData = new List<Orders>();
        private CustomerDB customerDB = new CustomerDB();

        private static CustomerManager? instance = null;

        public static CustomerManager Instance()
        {
            if (instance == null)
            {
                instance = new CustomerManager();
            }

            return instance;
        }

        public List<Customer> GetCustomerData()
        {
            return customerDB.GetCustomerAll();
        }

        public void AddCustomer(Customer customer)
        {
            customerDB.AddCustomerDB(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            customerDB.DeleteCustomerDB(customer);
        }

        public List<Orders> GetOrders()
        {
            return customerDB.GetOrderAll();
        }

        public void AddOrder(Orders order)
        {
            customerDB.AddOrdersDB(order);
        }

        public void DeleteOrder(Orders order)
        {
            customerDB.DeleteOrdersDB(order);
        }
    }
}
