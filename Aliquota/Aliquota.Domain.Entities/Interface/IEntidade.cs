using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Entities.Interface
{
    public interface IEntidade<T> 
    {
        T Id { get; set; }
        string Descricao { get;}
    }
}
