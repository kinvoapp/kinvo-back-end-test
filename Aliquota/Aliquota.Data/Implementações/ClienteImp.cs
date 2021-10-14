using Aliquota.Data.Context;
using Aliquota.Data.Contratos;
using Aliquota.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Data.Implementações
{
    public class ClienteImp : IClientePersist
    {
        private AliquotaContext context { get; }
        public ClienteImp(AliquotaContext _context)
        {
            this.context = _context;
        }
        public async Task<Cliente[]> GetAllClientes()
        {
            IQueryable<Cliente> query = context.Clientes;

            query = query.AsNoTracking().OrderBy(cliente => cliente.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Cliente> GetClienteById(int id)
        {
            IQueryable<Cliente> query = context.Clientes;

            query = query.AsNoTracking().OrderBy(cliente => cliente.Id);

            return await query.FirstOrDefaultAsync(cliente => cliente.Id == id);
        }

        public async Task<double> Resgatar(double valorBruto, double valorInvestido, double valorResgate, double lucro, int tempoDeInvestimento, int id, ComprovanteResgate comprovante)
        {
            Cliente cliente = await GetClienteById(id);

            double valorImposto = 0;

            if (tempoDeInvestimento <= 1)
            {
                lucro = valorBruto - valorInvestido;

                valorImposto = lucro * 0.225;

                valorResgate = valorInvestido + (lucro - valorImposto);

            }
            else if (tempoDeInvestimento > 1 && tempoDeInvestimento <= 2)
            {
                lucro = valorBruto - valorInvestido;

                valorImposto = lucro * 0.185;

                valorResgate = valorInvestido + (lucro - valorImposto);
            }
            else
            {
                lucro = valorBruto - valorInvestido;

                valorImposto = lucro * 0.15;

                valorResgate = valorInvestido + (lucro - valorImposto);
            }

            comprovante.DataResgate = DateTime.Now;
            comprovante.ValorResgate = valorResgate;

            if(comprovante.ValorResgate <= 0)
            {
                comprovante.ValorResgate = 0;
            }


            context.Add(comprovante);
            await context.SaveChangesAsync();

            return valorResgate;
        }
    }
}
