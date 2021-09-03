using Aliquota.Domain.Entities.Entidades;
using Aliquota.Domain.Repository.Implementacao.Base;
using Aliquota.Domain.Repository.Implementacao.Context;
using Aliquota.Domain.Repository.IRepositorios;
using Aliquota.Domin.Util.Excecoes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Repository.Implementacao.Repositorios
{
    public class ClienteRepositorio : BaseRepositorio<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(AliquotaDbContext context) : base(context)
        {
        }

        public async Task<Cliente> GetClienteComProduto(int id)
        {
            try
            {
                var cliente = _context.Clientes.Where(a => a.Id == id).FirstOrDefault();
                var produtoList = _context.Produtos.Where(a => a.IdCliente == cliente.Id).ToList();
                var tipoProdutoList = _context.TipoProdutos.ToList();
                produtoList.ForEach(a => a.TipoProduto = tipoProdutoList.First(b => b.Id == a.IdTipoProduto));
                cliente.ProdutoLista = produtoList;
                if (cliente == null)
                {
                    throw new NotFoundException(@"Objeto não encontrado no banco de dados! ");
                }

                return cliente;
            }
            catch (DbUpdateException ex)
            {
                throw new IntegridadeException("Não foi possível completar a busca da entidade ");
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
