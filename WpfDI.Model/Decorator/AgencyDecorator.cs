using System.Collections.Generic;
using WpfDI.Model.Interface.Model;

namespace WpfDI.Model.Decorator
{
    public class AgencyDecorator : IIAgencyDataAccess
    {
        public AgencyDecorator(IIAgencyDataAccess dataAccess, IIAgencyValidator validator)
        {
            DataAccess = dataAccess;
            Validator = validator;
        }

        private IIAgencyDataAccess DataAccess { get; set; }
        private IIAgencyValidator Validator { get; set; }

        public IEnumerable<Interface.Poco.Agency> SearchAgencies(string searchTerm)
        {
            Validator.ValidateAgencySearchRequest(searchTerm);

            return DataAccess.SearchAgencies(searchTerm);
        }
    }
}
