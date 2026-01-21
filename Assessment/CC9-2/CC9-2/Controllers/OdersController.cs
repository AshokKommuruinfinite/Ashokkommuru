using MVC_Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CC9_2.Controllers
{

    public class OrdersController : Controller

    {

        public async Task<ActionResult> ByEmployee(int employeeId)

        {

            List<OrderViewModel> orders = new List<OrderViewModel>();

            using (var client = new HttpClient(new HttpClientHandler

            {

                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true

            }))

            {

                client.BaseAddress = new Uri("https://localhost:44326/"); // Web API port

                var response = await client.GetAsync($"api/customers/getbyempid/{employeeId}");

                if (response.IsSuccessStatusCode)

                {

                    var jsonString = await response.Content.ReadAsStringAsync();

                    orders = JsonConvert.DeserializeObject<List<OrderViewModel>>(jsonString);

                }

                else

                {

                    ViewBag.Error = "Unable to get data from API";

                }

            }

            return View(orders);

        }

    }

}
