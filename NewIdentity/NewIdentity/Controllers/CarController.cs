using Microsoft.AspNetCore.Mvc;
using NewIdentity.Models;
using Newtonsoft.Json;
using System.Text;

namespace NewIdentity.Controllers
{
    public class CarController : Controller
    {

        private string url = "https://localhost:7168/api/Car/";
        private HttpClient client = new HttpClient();

        IWebHostEnvironment env;
        public CarController(IWebHostEnvironment env)
        {
            this.env = env;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CarImage car)
        {
            string filname = "";
            if (car != null) {
                
                string folder=Path.Combine(env.WebRootPath, "images");
                filname= Guid.NewGuid().ToString() + "_" + car.path.FileName;
                string filepath=Path.Combine(folder, filname);
                car.path.CopyTo(new FileStream(filepath,FileMode.Create));

                var carData = new
                {
                    name = car.name,
                    brand = car.brand,
                    model = car.model,
                    price = car.price,
                    year = car.year,
                    color = car.color,
                    stockQuantity = car.stockQuantity,
                    isAvailable = car.isAvailable,
                    imageUrl = "/images/" + filname
                };
                var data = JsonConvert.SerializeObject(carData);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {

                    TempData["success"] = "Customer Created Successfully ......";
                    return RedirectToAction("fatch");
                }
            }

            return View();
        }

        public IActionResult fatch()
        {
            List<Car> cars = new List<Car>();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Car>>(result);

                if (data != null)
                {
                    cars = data;
                }

            }
            return View(cars);
        }

    }
}
