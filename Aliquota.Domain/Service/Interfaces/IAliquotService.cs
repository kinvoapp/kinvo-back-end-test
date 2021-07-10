using Aliquota.Domain.DTO;
using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Service.Interfaces
{
    public interface IAliquotService
    {
        ResponseApplicationDTO GetApplication(int id);
        ResponseApplicationDTO Apply(ApplicationDTO model);
       WithdrawDTO Withdraw(RequestWithdrawDTO withdrawDTO);

    }
}
