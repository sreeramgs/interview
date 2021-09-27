using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Interview.Test.Api.Repository;
using Interview.Test.Api.Repository.Interface;
using Interview.Test.DataContracts;

namespace Interview.Test.Service.Tests
{
    public class ScenarioServiceTest
    {
        protected ScenarioService scenarioServiceTest { get; }
        private IScenarioRepository _iRepo;
        public ScenarioServiceTest()
        {

            List<Scenario> list = new List<Scenario>();
            list.Add(new Scenario()
            {
                ScenarioID = 1,
                Name = "Testname",
                Forename = "ForeName",
                Surname = "Surname",
                UserId = "6F55DFD1-A235-4BAE-B958-C1A0AB4D5236",
                MarketID = 1,
                NetworkLayerID = 1,
                NumMonths = 1,
                CreationDate = DateTime.Today,
                SampleDate = DateTime.Today



            });
            XDocument xdoc = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("Scenario",
                    from user in list
                    select
                        new XElement("ScenarioID",  user.ScenarioID,
                        new XElement("Name", user.UserId),
                        new XElement("Surname", user.Surname),
                        new XElement("Forename", user.Forename),
                        new XElement("UserID", user.UserId),
                        new XElement("SampleDate", user.SampleDate),
                        new XElement("CreationDate", user.CreationDate),
                        new XElement("NumMonths", user.NumMonths),
                        new XElement("MarketID", user.MarketID),
                        new XElement("NetworkLayerID", user.NetworkLayerID)
                    )));

            _iRepo = new ScenarioRepository(xdoc);
            scenarioServiceTest = new ScenarioService(_iRepo);
        }

    }
}
