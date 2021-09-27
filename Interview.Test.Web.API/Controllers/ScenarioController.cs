using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Interview.Test.Service;
using Interview.Test.Service.Interface;
using Interview.Test.Api.Repository;
using Interview.Test.Api.Repository.Interface;
using System.Web;
using Newtonsoft.Json;
namespace Interview.Test.Web.Api.Controllers
{
    public class ScenarioController : ApiController
    {
        private readonly IScenarioService _IScenarioService;
        private IScenarioRepository _repo;
        public ScenarioController()
        {


        }
        public ScenarioController(IScenarioService scenarioService)
        {
            _IScenarioService = scenarioService ?? throw new ArgumentNullException(nameof(scenarioService)); 

        }

        [Route("api/Scenario/All")]
        public IHttpActionResult GetAll()
        {


            _repo = new ScenarioRepository(HttpContext.Current.Server.MapPath("~/App_Data/Developer Technical Exercise.xml"));
            IScenarioService service = new ScenarioService(_repo);

            var list =  service.GetAll();
            //return Ok(JsonConvert.SerializeObject(list));
            return Ok(list);

        }
    }
}
