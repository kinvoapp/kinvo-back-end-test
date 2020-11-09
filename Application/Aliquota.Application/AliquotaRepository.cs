using System;
using System.Threading.Tasks;
using Aliquota.Infrastructure;
using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Application
{
    public class AliquotaRepository : IAsyncDisposable
    {
        private readonly AliquotaDbContext _dbContext;
        public AliquotaRepository()
        {
            _dbContext = new AliquotaDbContext();
        }

        public async Task CriarProdutoFinanceiro(ProdutoFinanceiro produtoFinanceiro)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Criando produto...");

            _dbContext.Add(produtoFinanceiro);
            await _dbContext.SaveChangesAsync();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Produto criado!");

            Console.ResetColor();
        }

        public async Task CriarCliente(Cliente cliente)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Criando cliente...");

            _dbContext.Add(cliente);
            await _dbContext.SaveChangesAsync();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Cliente criado!");

            Console.ResetColor();
        }

        public async Task<Cliente> CapturarClientePorCPF(string cpf)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Buscando cpf {cpf}...");

            Cliente cliente = await _dbContext.Clientes.Include( o => o.ProdutosFinanceiros).FirstOrDefaultAsync(o => o.CPF.Equals(cpf));
            if (cliente != null)
            {
                Console.WriteLine("Cpf encontrado!");
            }
            else
            {
                Console.WriteLine("Nenhum resultado encontrado!");
            }
            Console.ResetColor();
            return cliente;
        }

        public ValueTask DisposeAsync()
        {
            return _dbContext?.DisposeAsync() ?? default;
        }
    }
}