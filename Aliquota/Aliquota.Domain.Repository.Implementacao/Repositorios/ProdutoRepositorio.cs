using Aliquota.Domain.Entities.Entidades;
using Aliquota.Domain.Repository.Implementacao.Base;
using Aliquota.Domain.Repository.Implementacao.Context;
using Aliquota.Domain.Repository.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Repository.Implementacao.Repositorios
{
    public class ProdutoRepositorio : BaseRepositorio<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(AliquotaDbContext context) : base(context)
        {
        }
    }
}
