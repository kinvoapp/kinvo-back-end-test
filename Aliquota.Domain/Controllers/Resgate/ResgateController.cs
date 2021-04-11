using Aliquota.Domain.Data;
using Aliquota.Domain.Models;
using Aliquota.Domain.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Controllers.Resgate
{
    class ResgateController
    {
        ResgateRepo _resgateRepo = new ResgateRepo(new AliquotaContext());
        Comunicacao _comunicacao = new Comunicacao();
        DatasRepo _datasRepo = new DatasRepo();
        LucroRepo _lucroRepo = new LucroRepo();

        public void CriarResgate(Aplicacoes aplicacao, Resgates resgate)
        {
                resgate.AplicacaoId = aplicacao.Id;
                _resgateRepo.RetirarAplicacao(resgate);
        }

        

        public Resgates ListarSelecionarResgate()
        {
           List<Resgates> resgates = _resgateRepo.ListarResgates();
            Console.Clear();
            _comunicacao.TabelaResgates(resgates);
            Console.WriteLine("\n Digite o ID de um resgate para ver seus detalhes\n oudigite 'm' para voltar ao menu");

            string opcao = Console.ReadLine();

            if (opcao == "m")
            {
                Console.Clear();
                return null;
            }

            int id = 0;
            Resgates selecionado = new Resgates();
            while (id == 0)
            {
                try
                {
                    id = Int32.Parse(opcao);
                    selecionado = _resgateRepo.VerificarExistencia(resgates, id);
                    if(selecionado == null)
                    {
                        Console.WriteLine("ID invalido, tente novamente");
                        id = 0;
                        opcao = Console.ReadLine();
                        continue;
                    }
                }
                catch
                {
                    Console.WriteLine("ID invalido, tente novamente");
                    opcao = Console.ReadLine();
                    continue;
                }
            }
            return selecionado;

        }

        public Resgates DetalharResgateNaoCriado(Aplicacoes aplicacao)
        {
            Resgates resgate = new Resgates();
            resgate.Data = _comunicacao.ColetarValidarDataResgate(resgate.Data, aplicacao.Data);

            int totalMeses = _datasRepo.CalcularMesesAplicadosComHistorico(aplicacao, resgate);

            resgate.Lucro = _lucroRepo.CalcularLucroTotal(aplicacao, totalMeses);
            resgate.Valor_IR = _lucroRepo.CalcularValorIR(totalMeses, resgate.Lucro);
            resgate.Valor_Retirado = aplicacao.Valor + resgate.Lucro - resgate.Valor_IR;

            _comunicacao.DetalharResgates(aplicacao, resgate, totalMeses);

            return resgate;
        }

        public void DetalharResgate(Resgates resgate, Aplicacoes aplicacao)
        {
            int totalMeses = 0;

            if (aplicacao.Hisotricos != null)
            {
                if(aplicacao.Hisotricos.Count > 0)
                {
                    List<Historicos> hist = aplicacao.Hisotricos.OrderBy(p => p.Id).ToList();
                    totalMeses = _datasRepo.CalcularMesesAplicado(hist[0].Data, resgate.Data);
                }

            }
            else
            {
                totalMeses = _datasRepo.CalcularMesesAplicado(aplicacao.Data, resgate.Data);
            }

            _comunicacao.DetalharResgates(resgate.Aplicacao, resgate, totalMeses);

            Console.WriteLine("\nDigite qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

