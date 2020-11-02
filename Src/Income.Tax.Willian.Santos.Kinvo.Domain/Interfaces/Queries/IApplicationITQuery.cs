using Income.Tax.Willian.Santos.Kinvo.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Income.Tax.Willian.Santos.Kinvo.Domain.Interfaces.Queries
{
    public interface IApplicationITQuery
    {
        Task<List<ApplicationITDTO>> GetAll(); 
    }
}