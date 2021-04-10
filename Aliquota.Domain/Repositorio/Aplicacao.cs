using Aliquota.Domain.Data;
using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Repositorio
{
    class Aplicacao
    {
        readonly AliquotaContext _context;

        public Aplicacao(AliquotaContext context)
        {
            _context = context;
        }
        public void CadastrarAplicacao(Aplicacoes aplicacao)
        {
            try
            {
                _context.Aplicacoes.Add(aplicacao);
                _context.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Houve um erro no sistema, tente novamente mais tarde");
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
            return _context.Aplicacoes.ToList();
        }
    }
}
