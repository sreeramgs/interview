using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.Test.DataContracts;

namespace Interview.Test.Service.Interface
{
    public interface IScenarioService
    {
        IEnumerable<Scenario> GetAll();
        IEnumerable<Scenario> GetScenariosByUser(string UserID);
        Scenario GetScenarioByID(int ID);
    }
}
