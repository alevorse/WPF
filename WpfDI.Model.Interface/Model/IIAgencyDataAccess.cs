using System.Collections.Generic;
using WpfDI.Model.Interface.Poco;

namespace WpfDI.Model.Interface.Model
{
    public interface IIAgencyDataAccess
    {
        IEnumerable<Agency> SearchAgencies(string searchTerm);
    }
}
