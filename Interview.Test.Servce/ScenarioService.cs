using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.Test.DataContracts;
using Interview.Test.Service.Interface;
using Interview.Test.Api.Repository;
using Interview.Test.Api.Repository.Interface;

namespace Interview.Test.Service
{
    public class ScenarioService : IScenarioService
    {
        private readonly IScenarioRepository _scenarioRepo;

        public ScenarioService(IScenarioRepository scenarioRepo)
        {
            _scenarioRepo = scenarioRepo;
        }
        public IEnumerable<Scenario> GetAll()
        {
           return  _scenarioRepo.GetAll();
        }

        public Scenario GetScenarioByID(int ID)
        {
            return _scenarioRepo.GetScenarioByID(ID);
        }

        public  IEnumerable<Scenario> GetScenariosByUser(string UserID)
        {
            return  _scenarioRepo.GetScenarioListByUserID(UserID);
        }
    }
}
