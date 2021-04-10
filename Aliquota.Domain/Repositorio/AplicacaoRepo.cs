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

        public void DeletarAplicacao(Aplicacoes aplicacao)
        {
            try
            {
                _context.Remove(aplicacao);
                _context.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Houve um erro no sistema, tente novamente mais tarde");
            }
        }

        public List<Aplicacoes> ListarAplicacoes()
        {
            return _context.Aplicacoes.Include(h => h.Hisotricos).Where(a => a.Resgatada == false).ToList();
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
    }
}
