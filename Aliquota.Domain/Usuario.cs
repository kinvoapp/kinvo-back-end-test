using System;
using System.Collections.Generic;
using System.Linq;

namespace Aliquota.Domain
{
    public class Usuario : EntityBase
    {
        //public string Nome { get; set; }
        public List<Aplicacao> Aplicacoes { get; set; }

        public Usuario()
        {
            Aplicacoes = new List<Aplicacao>();
        }

        public void RegistrarAplicacao(double rentabilidade, double valor)
        {
            Aplicacoes.Add(new Aplicacao(rentabilidade, valor, this.Id));
        }

        public void ResgatarAplicacao(int IdAplicacao)
        {
            var aplicacao = Aplicacoes.SingleOrDefault(x => x.Id == IdAplicacao) ?? throw new ApplicationException("Aplicação não encontrada");

            aplicacao.Resgatar();
        }

        public IEnumerable<Aplicacao> ListarAplicacoes()
        {
            return Aplicacoes;
        }

        public void SimularResgateAplicacao(int IdAplicacao, DateTime dataResgate)
        {
            var aplicacao = Aplicacoes.SingleOrDefault(x => x.Id == IdAplicacao) ?? throw new ApplicationException("Aplicação não encontrada");

            aplicacao.Resgatar(dataResgate);

        }
    }
}
