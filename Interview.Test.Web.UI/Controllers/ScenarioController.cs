using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using Interview.Test.DataContracts;
namespace Interview.Test.Web.UI.Controllers
{
    public class ScenarioController : Controller
    {
        string Baseurl = "http://localhost:55796/";
        // GET: Scenario
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View();
            //return await GetAll();
        }
        public async Task<ActionResult> GetAll()
        {
            string result = string.Empty;
            List<Scenario> scenarios = new List<Scenario>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Scenario/All");
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    scenarios = JsonConvert.DeserializeObject<List<Scenario>>(Response);
                }
            }
            return Json(new { data = scenarios },JsonRequestBehavior.AllowGet);

        }
        public async Task<ActionResult> GetAllByUser(string userId)
        {
            string result = string.Empty;
            List<Scenario> scenarios = new List<Scenario>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Scenario/All");
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    scenarios = JsonConvert.DeserializeObject<List<Scenario>>(Response);
                }
            }
            return Json(new { data = scenarios }, JsonRequestBehavior.AllowGet);

        }

    }
}