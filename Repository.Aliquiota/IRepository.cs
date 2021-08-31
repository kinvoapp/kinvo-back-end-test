using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Aliquiota
{
    interface IRepository<o>
    {
        bool Cadastrar(o objeto);
        o BuscarPorId(int id);
        List<o> Listar();
    }
}
