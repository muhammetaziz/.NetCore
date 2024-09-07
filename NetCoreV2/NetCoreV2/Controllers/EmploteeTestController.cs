using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace NetCoreV2.Controllers
{
    public class EmploteeTestController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responceMessage = await httpClient.GetAsync("https://localhost:7129/api/Default");

            var jsonString = await responceMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);


            return View(values);
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Class1 p)
        {
            var httpClient=new HttpClient();
            var jasonEmployee=JsonConvert.SerializeObject(p);
            StringContent content=new StringContent(jasonEmployee,Encoding.UTF8,"application/json");
            var responceMessage = await httpClient.PostAsync("https://localhost:7129/api/Default", content);
            if(responceMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var httpClient=new HttpClient();
            var responceMessage=await httpClient.GetAsync("https://localhost:7129/api/Default/"+id);
            if (responceMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await responceMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<Class1>(jsonEmployee);
                return View(values);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployee(Class1 p)
        {
            var httpClient=new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            var content=new StringContent(jsonEmployee,Encoding.UTF8,"application/json");
            var responceMessage = await httpClient.PutAsync("https://localhost:7129/api/Default", content);
            if (responceMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var httpClient = new HttpClient();
            var responceMessage = await httpClient.DeleteAsync("https://localhost:7129/api/Default/" + id);
            if (responceMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
                 
            }
            return View();
        }
    }
    public class Class1
    {
        public int ID { get; set; }
        public string Name { get; set; }


    }
}
