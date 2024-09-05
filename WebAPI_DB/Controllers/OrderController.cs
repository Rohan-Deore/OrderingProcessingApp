using Microsoft.AspNetCore.Mvc;

namespace WebAPI_DB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetOrder")]
        public IEnumerable<Orders> Get()
        {
            return CustomerManager.Instance().GetOrders();
        }


        [HttpPost(Name = "PostOrder")]
        public void Post(Orders order)
        {
            CustomerManager.Instance().AddOrder(order);
        }

        [HttpDelete(Name = "DeleteOrder")]
        public void Delete(Orders order)
        {
            CustomerManager.Instance().DeleteOrder(order);
        }
    }
}
