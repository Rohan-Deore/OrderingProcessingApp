using System.Net.Http;
using System.Net.Http.Json;

namespace OrderProcessingWPF
{
    public class LicenseCheckResult
    {
        public bool IsLicensed { get; set; }

        public string ErrorMessage { get; set; } = string.Empty;
    }

    internal class LicenseChecker
    {
        internal async Task<string> GetLicenseStatus()
        {
            //string msg = await GetData();
            var msg = GetData();

            return msg.Result;
        }

        //private string GetData()
        private async Task<string> GetData()
        {
            try
            {
                var defaultSettings = Properties.Settings.Default;

                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri($"{defaultSettings.LicenseServer}");
                string MachineID = string.Empty;

                // TODO : Remove Hard coded data for testing purpose
                var responseMessage = client.GetAsync($"{defaultSettings.UserName}, {defaultSettings.CompanyName}, {defaultSettings.ApplicationName}, {Environment.MachineName}");
                HttpResponseMessage response = responseMessage.Result;
                if (response.IsSuccessStatusCode)
                {
                    var licenseResult = response.Content.ReadFromJsonAsync<LicenseCheckResult>();
                    if (licenseResult == null)
                    {
                        return "Error Code " + response.StatusCode + " : Message - " + response.ReasonPhrase;
                    }

                    //usergrid.ItemsSource = users;
                    return licenseResult.Result.ErrorMessage;
                }
                else
                {
                    return "Error Code " + response.StatusCode + " : Message - " + response.ReasonPhrase;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return string.Empty;
            }
        }

        //private void GetCustomer()
        //{
        //    try
        //    {
        //        HttpClient client = new HttpClient();
        //        //HttpResponseMessage response = await client.GetAsync("https://localhost:7293/Order/");
        //        HttpResponseMessage response = await client.GetAsync("https://localhost:7293/Customer/");
        //        response.EnsureSuccessStatusCode();
        //        string responseBody = await response.Content.ReadAsStringAsync();

        //        //var m1 = JsonConvert.DeserializeObject<List<Order>>(responseBody);
        //        var m2 = JsonConvert.DeserializeObject<List<Customer>>(responseBody);

        //        // Process the response body here
        //        uiService.ShowUserMessage(responseBody);
        //    }
        //    catch (HttpRequestException e)
        //    {
        //        uiService.ShowUserMessage($"Request error: {e.Message}");
        //    }
        //}
    }
}
