using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.Test.DataContracts;

namespace Interview.Test.Api.Repository.Interface
{
    public interface IScenarioRepository
    {
        IEnumerable<Scenario> GetAll();
        Scenario GetScenarioByID(int ScenarioID);
        IEnumerable<Scenario> GetScenarioListByUserID(string UserID);
        Scenario Insert(Scenario Item);
        bool Update(Scenario Item);
        bool Remove(Scenario Item);

    }

}
