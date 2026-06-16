using Microsoft.AspNetCore.Mvc;
using NewIdentity.Models;
using Newtonsoft.Json;
using System.Text;

namespace NewIdentity.Controllers
{
    public class CustomerController : Controller
    {
        private string url = "https://localhost:7168/api/Customer/";
        private HttpClient client= new HttpClient();


        [HttpGet]
        public IActionResult Index()
        {
            List<Customer> customers = new List<Customer>();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode) { 
            string result =response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Customer>>(result);

                if (data != null) {
                customers= data;
                }

            }
            return View(customers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            var data = JsonConvert.SerializeObject(customer);
            StringContent content = new StringContent(data,Encoding.UTF8,"application/json");
            HttpResponseMessage response = client.PostAsync(url,content).Result;
            if (response.IsSuccessStatusCode) {

                TempData["success"] = "Customer Created Successfully ......";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult edit(int id)
        {
           Customer customerdata = new Customer();
            HttpResponseMessage response = client.GetAsync(url+id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Customer>(result);

                if (data != null)
                {
                    customerdata = data;
                }

            }
            return View(customerdata);
        }

        [HttpPost]
        public IActionResult edit(Customer customer)
        {
            var data = JsonConvert.SerializeObject(customer);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(url+customer.id, content).Result;
            if (response.IsSuccessStatusCode)
            {

                TempData["success"] = "Customer Updated Successfully ......";
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public IActionResult details(int id)
        {
            Customer customerdata = new Customer();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Customer>(result);

                if (data != null)
                {
                    customerdata = data;
                }

            }
            return View(customerdata);
        }
        [HttpGet]
        public IActionResult delete(int id)
        {
            Customer customerdata = new Customer();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Customer>(result);

                if (data != null)
                {
                    customerdata = data;
                }

            }
            return View(customerdata);
        }

        [HttpPost,ActionName("delete")]
        public IActionResult deleteconfirmed(int id)
        {
           
            HttpResponseMessage response = client.DeleteAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {

                TempData["success"] = "Customer Deleted Successfully ......";
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
