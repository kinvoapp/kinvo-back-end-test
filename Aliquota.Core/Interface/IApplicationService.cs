using Aliquota.Core.DTO;

namespace Aliquota.Core.Interface
{
    public interface IApplicationService
    {
        /// <summary>
        /// Create a new Application
        /// </summary>
        /// <parameter name="value">value of the application</parameter>
        /// <parameter name="fantasyName">fantasy name for the application</parameter>
        void Create(decimal value, string fantasyName);

        /// <summary>
        /// Withdraw an share value, gettin back the value after taxes are paid
        /// </summary>
        /// <parameter name="fantasyName">fantasy name to search the application</parameter>
        /// <returns>WithDrawApplicationDto object</returns>
        WithDrawApplicationDto WithDrawShareApplication(string fantasyName);
    }
}
