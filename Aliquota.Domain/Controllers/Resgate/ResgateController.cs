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

        public string FluxoResgatarAplicacao(Aplicacoes aplicacao)
        {

            Console.WriteLine("Quer fazer a retirada desta aplicacao?");
            Console.WriteLine("Para ver os dados do resgate digite 'r' para cancelar digite 'c'");
            string confirmacao = Console.ReadLine();
            while (confirmacao != "r" && confirmacao != "c")
            {
                Console.WriteLine("Opcao invalida, tente novamente");
                confirmacao = Console.ReadLine();
            }

            if (confirmacao == "r")
            {
                Resgates resgate = new Resgates();
                resgate.Data = _comunicacao.ColetarValidarDataResgate(resgate.Data, aplicacao.Data);
                int totalMeses = _datasRepo.CalcularMesesAplicado(aplicacao.Data, resgate.Data);
                resgate.Lucro = _lucroRepo.CalcularLucroTotal(aplicacao, totalMeses);
                resgate.Valor_IR = _lucroRepo.CalcularValorIR(totalMeses, resgate.Lucro);
                resgate.Valor_Retirado = aplicacao.Valor + resgate.Lucro - resgate.Valor_IR;

                _comunicacao.DetalharResgates(aplicacao, resgate, totalMeses);

                Console.WriteLine("Para realizar o resgate digite 'r' para cancelar operacao digite 'c'");
                confirmacao = Console.ReadLine();

                while (confirmacao != "r" && confirmacao != "c")
                {
                    Console.WriteLine("Opcao invalida, tente novamente");
                    confirmacao = Console.ReadLine();
                }

                if (confirmacao == "r")
                {
                    resgate.AplicacaoId = aplicacao.Id;
                    _resgateRepo.RetirarAplicacao(resgate);
                    return "r";
                }
                else
                    return "c";
            }
            else
                return "c";
        }

        public void FluxoSelecionarResgate()
        {
           List<Resgates> resgates = _resgateRepo.ListarResgates();
            Console.Clear();
            _comunicacao.TabelaResgates(resgates);
            Console.WriteLine("\n Digite o ID de um resgate para ver seus detalhes\n oudigite 'm' para voltar ao menu");

            string opcao = Console.ReadLine();

            int id = 0;
            Resgates selecionado = new Resgates();
            while (id == 0 || selecionado == null)
            {
                try
                {
                    id = Int32.Parse(opcao);
                    selecionado = _resgateRepo.VerificarExistencia(resgates, id);
                }
                catch
                {
                    Console.WriteLine("ID invalido, tente novamente");
                    opcao = Console.ReadLine();
                }
            }

            int totalMeses = _datasRepo.CalcularMesesAplicado(selecionado.Aplicacao.Data, selecionado.Data);

            _comunicacao.DetalharResgates(selecionado.Aplicacao, selecionado, totalMeses);

            Console.WriteLine("\nDigite qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Console.Clear();

        }
    }
}

