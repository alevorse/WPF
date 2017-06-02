using System.Collections.Generic;
using System.Linq;
using WpfDI.Model.Interface.Model;

namespace WpfDI.Model.DataAccess
{
    public class AgencyDataAccess : IIAgencyDataAccess
    {
        public IEnumerable<Interface.Poco.Agency> SearchAgencies(string searchTerm)
        {
            var agencies = new List<Interface.Poco.Agency> { new Interface.Poco.Agency { Name = "Test Agency", ProducerId = "AGT1351" } };

            return agencies.Where(a => a.ProducerId.Contains(searchTerm) || a.Name.Contains(searchTerm));
        }
    }
}
