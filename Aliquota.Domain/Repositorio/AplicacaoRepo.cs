using Aliquota.Domain.Data;
using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Repositorio
{
    class AplicacaoRepo
    {
        readonly AliquotaContext _context;
        LucroRepo _lucroRepo = new LucroRepo();
        DatasRepo _dataRepo = new DatasRepo();

        public AplicacaoRepo(AliquotaContext context)
        {
            _context = context;
        }

        public void CadastrarAplicacao(Aplicacoes aplicacao)
        {
            try
            {
                _context.Aplicacoes.Add(aplicacao);
                _context.SaveChanges();
                Console.WriteLine("Aplicacao cadastrada com sucesso!");
                Console.WriteLine("\nDigite qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
            catch
            {
                Console.WriteLine("Houve um erro no sistema, tente novamente mais tarde");
                Console.WriteLine("\nDigite qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public List<Aplicacoes> ListarAplicacoes()
        {
            List<Aplicacoes> lista = new List<Aplicacoes>();

            lista = _context.Aplicacoes.Include(h => h.Hisotricos).Where(a => a.Resgatada == false).ToList();

            return lista;
        }

        public Aplicacoes VerificaExistencia(List<Aplicacoes> app, int id)
        {
            return app.Find(i => i.Id == id);
        }

        public void ResgatarAplicacao(Aplicacoes app)
        {
            Aplicacoes editada = app;
            editada.Resgatada = true;

            _context.Entry(app).CurrentValues.SetValues(editada);
            _context.SaveChanges();
        }

        public void Aplicar(Aplicacoes apl, Aplicacoes antiga)
        {
            try
            {

                Historicos hist = new Historicos
                {
                    Valor = antiga.Valor,
                    Data = antiga.Data,
                    AplicacaoId = antiga.Id
                };

                int totalMeses = _dataRepo.CalcularMesesAplicado(antiga.Data, apl.Data);

                hist.Lucro = _lucroRepo.CalcularLucroTotal(antiga, totalMeses);

                apl.Valor += antiga.Valor;
                apl.Rentabilidade_Mes = antiga.Rentabilidade_Mes;
                apl.Id = antiga.Id;

                _context.Entry(antiga).CurrentValues.SetValues(apl);
            
                hist.Lucro = _lucroRepo.CalcularLucroTotal(antiga, totalMeses);

                _context.Historicos.Add(hist);

                _context.SaveChanges();

                Console.WriteLine("Aplicacao realizada com sucesso!");
                Console.WriteLine("\nDigite qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
            catch
            {
                Console.WriteLine("Houve um erro no sistema, tente novamente mais tarde");
                Console.WriteLine("\nDigite qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
