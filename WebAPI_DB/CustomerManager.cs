namespace WebAPI_DB
{
    public class CustomerManager
    {
        private List<Customer> customerData = new List<Customer>();
        private List<Orders> orderData = new List<Orders>();
        private CustomerDB customerDB = new CustomerDB();

        private static CustomerManager instance;

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
            customerData.Add(customer);
        }

        public void Delete(Customer customer)
        {
            for (int i = 0; i < customerData.Count; i++)
            {
                if (customerData[i].Equals(customer))
                {
                    customerData.RemoveAt(i);
                    break;
                }
            }
        }

        public List<Orders> GetOrders()
        {
            return orderData;
        }
    }
}
