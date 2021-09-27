using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Interview.Test.DataContracts
{
    [DataContract]
    public class Scenario
    {
        [DataMember]
        public int ScenarioID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string Forename { get; set; }
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public DateTime? SampleDate { get; set; }
        [DataMember]
        public DateTime? CreationDate { get; set; }
        [DataMember]
        public int NumMonths { get; set; }
        [DataMember]
        public int MarketID { get; set; }
        [DataMember]
        public int NetworkLayerID { get; set; }
    }
}
