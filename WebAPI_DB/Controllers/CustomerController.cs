using Microsoft.AspNetCore.Mvc;

namespace WebAPI_DB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCustomer")]
        public IEnumerable<Customer> Get()
        {
            return CustomerManager.Instance().GetCustomerData();
        }

        [HttpPost(Name = "PostCustomer")]
        public void Post(Customer customer)
        {
            CustomerManager.Instance().Add(customer);
        }

        [HttpDelete(Name = "DeleteCustomer")]
        public void Delete(Customer customer)
        {
            CustomerManager.Instance().Delete(customer);
        }
    }
}
