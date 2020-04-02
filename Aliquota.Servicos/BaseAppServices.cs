using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Aliquota.Servicos
{
    public class BaseAppServices<PrimaryKey, Entidade>
    {

        private InfraFactory _infraFactory;
        internal BaseAppServices(InfraFactory a_InfraFactory)
        {
            _infraFactory = a_InfraFactory;
        }

    }

    public delegate object InfraFactory();

    public interface IBaseAppService<PrimaryKey, Entidade>
    {

        IList<Entidade> Listar();

        IList<Entidade> Listar(Expression<Func<Entidade, bool>> a_Predicado);

        Entidade Obter(PrimaryKey a_PrimaryKey);

        Entidade Salvar(Entidade a_Modelo, Guid a_UsuarioId);

        Entidade Excluir(PrimaryKey a_PrimaryKey, Guid a_UsuarioId);
    }
}
