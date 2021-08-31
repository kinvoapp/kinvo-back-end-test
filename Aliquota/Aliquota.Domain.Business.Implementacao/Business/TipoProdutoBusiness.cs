using Aliquota.Domain.Business.IBusiness;
using Aliquota.Domain.Business.Implementacao.Base;
using Aliquota.Domain.Business.Validation;
using Aliquota.Domain.Entities.Entidades;
using Aliquota.Domain.Repository.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Business.Implementacao.Business
{
    public class TipoProdutoBusiness : BusinessCrudBase<TipoProduto>, ITipoProdutoBusiness
    {
        public TipoProdutoBusiness(ITipoProdutoRepositorio agenteconcessaoRepository, IValidation<TipoProduto> validator)
            : base()
        {
            _repository = agenteconcessaoRepository;
            Validator = validator;
        }
    }
}
