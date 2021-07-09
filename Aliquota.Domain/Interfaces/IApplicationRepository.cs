using Aliquota.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Interfaces
{
    public interface IApplicationRepository
    {
        Application GetApplication(int id);
        Application Apply(Application application);
        Application Withdraw(Application application);


    }
}
