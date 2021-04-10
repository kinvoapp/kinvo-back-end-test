using Aliquota.Domain.Controllers.Aplicacao;
using Aliquota.Domain.Data;
using Aliquota.Domain.Models;
using Aliquota.Domain.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Controllers
{
    class AplicacaoController
    {
        AplicacaoRepo _aplicacaoRepo = new AplicacaoRepo(new AliquotaContext());
        Comunicacao _comunicacao = new Comunicacao();


        public List<Aplicacoes> ListarAplicacoes()
        {
            return _aplicacaoRepo.ListarAplicacoes();
        }

        public Aplicacoes FluxoAdicionarAplicacao(Aplicacoes aplicacao)
        {
            Console.Clear();
            Console.WriteLine("\n\n\tPreencha os dados abaixo");

            aplicacao.Valor = _comunicacao.ColetarValidarValorAplicacao(aplicacao.Valor);
            aplicacao.Data = _comunicacao.ColetarValidarDataAplicacao(aplicacao.Data);
            aplicacao.Rentabilidade_Mes = _comunicacao.ColetarValidarRentabilidadeAplicacao(aplicacao.Rentabilidade_Mes);
            aplicacao.Resgatada = false;
            _aplicacaoRepo.CadastrarAplicacao(aplicacao);

            return aplicacao;
        }

        public void FluxoSelecionarAplicacao(List<Aplicacoes> lista, string acao)
        {
            int id = 0;
            Aplicacoes selecionada = new Aplicacoes();
            while (id == 0 || selecionada == null)
            {
                try
                {
                    id = Int32.Parse(acao);
                     selecionada = _aplicacaoRepo.VerificaExistencia(lista, id);
                }
                catch
                {
                    Console.WriteLine("ID invalido, tente novamente");
                    acao = Console.ReadLine();
                }
            }

            _comunicacao.DetalharAplicacao(selecionada);


        }

        public void ResgatarAplicacao(Aplicacoes app)
        {
            _aplicacaoRepo.ResgatarAplicacao(app);
        }

    }
}
