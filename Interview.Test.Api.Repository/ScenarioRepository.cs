using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Interview.Test.Api.Repository.Interface;
using Interview.Test.DataContracts;


namespace Interview.Test.Api.Repository
{
    public class ScenarioRepository : IScenarioRepository
    {
        private List<Scenario> scenarios = new List<Scenario>();
        private XDocument xDocument;

        public ScenarioRepository()
        {
        }
        public ScenarioRepository(string uri)
        {
            xDocument = XDocument.Load(uri);
            try
            {
                xDocument.Descendants("Scenario").ToList().ForEach(x =>
                {
                    try
                    {
                        int nummonths;
                        scenarios.Add(new Scenario()
                        {
                            ScenarioID = Int32.Parse(x.Descendants("ScenarioID").FirstOrDefault().Value),
                            Name = x.Descendants("Name").FirstOrDefault() == null ? null : x.Descendants("Name").FirstOrDefault().Value,
                            Surname = x.Descendants("Surname").FirstOrDefault() == null ? null : x.Descendants("Surname").FirstOrDefault().Value,
                            Forename = x.Descendants("Forename").FirstOrDefault() == null ? null : x.Descendants("Forename").FirstOrDefault().Value,
                            UserId = x.Descendants("UserID").FirstOrDefault() == null ? null : x.Descendants("UserID").FirstOrDefault().Value,
                            SampleDate = x.Descendants("SampleDate").FirstOrDefault() == null ? (DateTime?)null : DateTime.Parse(x.Descendants("SampleDate").FirstOrDefault().Value), 
                            CreationDate = x.Descendants("CreationDate").FirstOrDefault() == null ? (DateTime?)null : DateTime.Parse(x.Descendants("CreationDate").FirstOrDefault().Value),
                            NumMonths =  int.TryParse(x.Descendants("NumMonths").FirstOrDefault().Value, out nummonths) ? nummonths : 0,
                            MarketID =  x.Descendants("MarketID").FirstOrDefault() == null ? 0 :  Int32.Parse(x.Descendants("MarketID").FirstOrDefault().Value), //int.TryParse(x.Descendants("MarketID").FirstOrDefault().Value, out martketid) ? martketid : 0,
                            NetworkLayerID = x.Descendants("NetworkLayerID").FirstOrDefault() == null ? 0 : Int32.Parse(x.Descendants("NetworkLayerID").FirstOrDefault().Value) //int.TryParse(x.Descendants("NetworkLayerID").FirstOrDefault().Value, out networkID) ? networkID : 0,
                        });
                    }
                    catch (Exception ex)
                    {

                    }
                });
            }
            catch (Exception ex)
            {
                ///log the error
            }
        }

        public ScenarioRepository(XDocument xDocument)
        {
            try
            {
                xDocument.Descendants("Scenario").ToList().ForEach(x =>
                {
                    scenarios.Add(new Scenario()
                    {
                        ScenarioID = Int32.Parse(x.Descendants("ScenarioID").FirstOrDefault().Value),
                        Name = x.Descendants("Name").FirstOrDefault().Value,
                        Surname = x.Descendants("SurName").FirstOrDefault().Value,
                        Forename = x.Descendants("Forename").FirstOrDefault().Value,
                        UserId = x.Descendants("UserID").FirstOrDefault().Value,
                        SampleDate = DateTime.Parse(x.Descendants("SampleDate").FirstOrDefault().Value),
                        CreationDate = DateTime.Parse(x.Descendants("CreationDate").FirstOrDefault().Value),
                        NumMonths = Int16.Parse(x.Descendants("NumMonths").FirstOrDefault().Value),
                        MarketID = Int32.Parse(x.Descendants("MarketID").FirstOrDefault().Value),
                        NetworkLayerID = Int32.Parse(x.Descendants("NetworkLayerID").FirstOrDefault().Value)
                    });
                });
            }
            catch (Exception ex)
            {
                ///log the error
            }
        }
        public  IEnumerable<Scenario> GetAll()
        {
            return scenarios.AsQueryable().ToList();
        }

        public Scenario GetScenarioByID(int ScenarioID)
        {
            return scenarios.Where(x => x.ScenarioID == ScenarioID).FirstOrDefault();
        }

        public IEnumerable<Scenario> GetScenarioListByUserID(string UserID)
        {
            return scenarios.AsQueryable().Where(x => x.UserId == UserID).ToList();
        }

        public  Scenario Insert(Scenario Item)
        {
            throw new NotImplementedException();
        }

        public  bool Remove(Scenario Item)
        {
            throw new NotImplementedException();
        }

        public  bool Update(Scenario Item)
        {
            throw new NotImplementedException();
        }
    }
}
