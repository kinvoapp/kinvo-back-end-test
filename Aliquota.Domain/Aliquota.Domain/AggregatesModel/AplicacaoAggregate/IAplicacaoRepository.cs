using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.AggregatesModel.AplicacaoAggregate
{ 
    public interface IAplicacaoRepository
    {
        Aplicacao Add(Aplicacao aplicacao);

        void Update(Aplicacao aplicacao);

        public Aplicacao GetAplicacaoById(int id);

        public void Remove(Aplicacao aplicacao);

    }
}
