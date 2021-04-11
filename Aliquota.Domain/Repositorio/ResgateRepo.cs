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
    class ResgateRepo
    {
        readonly AliquotaContext _context;

        public ResgateRepo(AliquotaContext context)
        {
            _context = context;
        }

        public void RetirarAplicacao(Resgates resgate)
        {
            try
            {
                _context.Resgates.Add(resgate);
                _context.SaveChanges();
                Console.WriteLine("Resgate realizado com sucesso!");
                Console.WriteLine("\nDigite qualquer tecla para continuar...");
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Houve um erro no sistema, tente novamente mais tarde");
                Console.WriteLine("\nDigite qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public List<Resgates> ListarResgates()
        {
            return _context.Resgates.Include(a => a.Aplicacao).ToList();
        }

        public Resgates VerificarExistencia(List<Resgates> lista, int id)
        {
            return lista.Find(i => i.Id == id);
        }
    }
}
