using WpfDI.Model.Interface.Model;

namespace WpfDI.Model.Validator
{
    public class AgencyValidator : IIAgencyValidator
    {
        public bool ValidateAgencySearchRequest(string searchTerm)
        {
            return true;
        }
    }
}
