using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Validators.Interfaces.Base
{
    public interface IBaseValidator<T, TRequest>
    {
        Task ValidateCreation(TRequest request);
        Task<T> ValidateEdit(Guid? uuid, TRequest request);
        Task<T> ValidateRemove(Guid? uuid);
    }
}
