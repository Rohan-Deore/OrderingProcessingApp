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
            return customerDB.GetAll();
        }

        public void Add(Customer customer)
        {
            customerDB.AddCustomerDB(customer);
        }

        public void Delete(Customer customer)
        {
            customerDB.DeleteCustomerDB(customer);
        }

        public List<Orders> GetOrders()
        {
            return orderData;
        }
    }
}
