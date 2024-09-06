using Model;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace ViewModel.Commands
{
    public class AddProductCommand : CommandBase
    {
        internal OrderDetailsVM ViewModelBase { get; }
        public AddProductCommand(OrderDetailsVM vmBase, IUiService service) : base(service)
        {
            ViewModelBase = vmBase;
        }

        public override void Execute(object? parameter)
        {
            uiService.ShowUserMessage("Pop up shown");
            //FetchData();
            //PostData();
            DeleteData();
        }

        private async void FetchData()
        {
            try
            {
                HttpClient client = new HttpClient();
                //HttpResponseMessage response = await client.GetAsync("https://localhost:7293/Order/");
                HttpResponseMessage response = await client.GetAsync("https://localhost:7293/Customer/");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                //var m1 = JsonConvert.DeserializeObject<List<Order>>(responseBody);
                var m2 = JsonConvert.DeserializeObject<List<Customer>>(responseBody);

                // Process the response body here
                uiService.ShowUserMessage(responseBody);
            }
            catch (HttpRequestException e)
            {
                uiService.ShowUserMessage($"Request error: {e.Message}");
            }
        }

        private async void PostData()
        {
            var data = new Customer
            {
                CustomerName = "Rohan Deore",
                CustomerLocation = "Pune"
            };

            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.PostAsync("https://localhost:7293/Customer/", content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Process the response body here
                uiService.ShowUserMessage(responseBody);
            }
            catch (HttpRequestException e)
            {
                uiService.ShowUserMessage($"Request error: {e.Message}");
            }
        }

        private async void DeleteData()
        {
            var data = new Customer
            {
                CustomerName = "Rohan",
                CustomerLocation = "Pune"
            };
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.DeleteAsync($"https://localhost:7293/Customer/{content}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Process the response body here
                uiService.ShowUserMessage(responseBody);
            }
            catch (HttpRequestException e)
            {
                uiService.ShowUserMessage($"Request error: {e.Message}");
            }
        }
    }
}
