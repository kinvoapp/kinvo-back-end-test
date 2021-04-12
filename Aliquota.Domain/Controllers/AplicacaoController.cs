using Aliquota.Domain.Data;
using Aliquota.Domain.Models;
using Aliquota.Domain.Repositorio;
using Aliquota.Domain.Repositorio.Comunicacao;
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
        AplicacaoComunicacao _comunicacao = new AplicacaoComunicacao();


        public List<Aplicacoes> ListarAplicacoes()
        {
            return _aplicacaoRepo.ListarAplicacoes();
        }

        public Aplicacoes AdicionarAplicacao(Aplicacoes aplicacao)
        {
            Console.Clear();
            Console.WriteLine("\n\n\tPreencha os dados abaixo");

            while (aplicacao.Valor <= 0)
            {
                Console.WriteLine("\nQual o valor da aplicacao?\n");
                string resposta = Console.ReadLine();

                aplicacao.Valor = _comunicacao.ColetarValidarValorAplicacao(resposta);
            }
            aplicacao.Data = _comunicacao.ColetarValidarDataAplicacao(aplicacao.Data);
            aplicacao.Rentabilidade_Mes = _comunicacao.ColetarValidarRentabilidadeAplicacao(aplicacao.Rentabilidade_Mes);
            aplicacao.Resgatada = false;
            _aplicacaoRepo.CadastrarAplicacao(aplicacao);

            return aplicacao;
        }

        public Aplicacoes SelecionarAplicacao(List<Aplicacoes> lista, string acao)
        {
            int id = 0;
            Aplicacoes selecionada = new Aplicacoes();
            while (id == 0 || selecionada == null)
            {
                try
                {
                    id = Int32.Parse(acao);
                     selecionada = _aplicacaoRepo.VerificaExistencia(lista, id);
                    if(selecionada == null)
                    {
                        Console.WriteLine("ID invalido, tente novamente");
                        acao = Console.ReadLine();
                        continue;
                    }
                }
                catch
                {
                    Console.WriteLine("ID invalido, tente novamente");
                    acao = Console.ReadLine();
                    continue;
                }
            }

            _comunicacao.DetalharAplicacao(selecionada);

            return selecionada;

        }

        public Aplicacoes BuscarAplicacaoPorId(int id)
        {
            return _aplicacaoRepo.BuscaPorId(id);
        }

        public void RealizarInvestimento(Aplicacoes selecionada)
        {
            Aplicacoes aplicacao = new Aplicacoes();
            Console.WriteLine("\n\n\tPreencha os dados abaixo");

            while (aplicacao.Valor <= 0)
            {
                Console.WriteLine("\nQual o valor da aplicacao?\n");
                string resposta = Console.ReadLine();

                aplicacao.Valor = _comunicacao.ColetarValidarValorAplicacao(resposta);
            }

            aplicacao.Data = _comunicacao.ColetarValidarDataInvestimento(selecionada.Data);
            aplicacao.Resgatada = false;

            _aplicacaoRepo.Aplicar(aplicacao, selecionada);
        }

        public void ResgatarAplicacao(Aplicacoes app)
        {
            _aplicacaoRepo.ResgatarAplicacao(app);
        }

    }
}
