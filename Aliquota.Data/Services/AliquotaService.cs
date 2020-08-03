    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Aliquota.Data.Services.EF;
    using Aliquota.Domain.Model;
    using Microsoft.EntityFrameworkCore;

    namespace Aliquota.Data.Services
    {
        public class AliquotaService : IAliquotaService
    {
            private readonly InvestimentoDbContext contexto;

            public AliquotaService(InvestimentoDbContext context)
            {
                contexto = context;
            }

            public async Task<bool> AdicionarProduto(uint id,string nome,decimal taxa, DateTime vencimento)
            {
                try
                {
                    if (await ExistProdutoByIdAsync(id))
                    {
                        throw new ApplicationException("Id do produto já existe!");
                    }
                    var produto = new Produto(id,nome,taxa,vencimento);
                    contexto.Produto.Add(produto);
                    await contexto.SaveChangesAsync().ConfigureAwait(false);
                    return await ExistProdutoByIdAsync(produto.Id);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            
            }

            public async Task<bool> ExistProdutoByIdAsync(uint id)
            {
                try
                {
                    return await contexto.Produto.AsNoTracking().AnyAsync(produto => produto.Id.Equals(id)).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public async Task<Produto> GetProdutoByIdAsync(uint id)
            {
                try
                {
                    return await contexto.Produto
                    .FirstOrDefaultAsync(produto => produto.Id.Equals(id)).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public async Task<bool> AdicionarCarteira( string nome)
            {
                try
                {
                    if (await ExistCarteiraByNomeAsync(nome))
                    {
                        throw new ApplicationException("Id do produto já existe!");
                    }
                    var carteira = new Carteira(nome);
                    contexto.Carteira.Add(carteira);
                    await contexto.SaveChangesAsync().ConfigureAwait(false);
                    return await ExistCarteiraByNomeAsync(nome);

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            public async Task<bool> ExistCarteiraByNomeAsync(string nome)
            {
                try
                {
                    return await contexto.Carteira.AsNoTracking()
                        .AnyAsync(carteira => carteira.NomeCliente.Equals(nome)).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public async Task<Carteira> GetCarteiraByNomeAsync(string nome)
            {
                try
                {
                    return await contexto.Carteira.FirstOrDefaultAsync(carteira => carteira.NomeCliente.Equals(nome))
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public async Task<Carteira> GetCarteiraByNomeAsync(Guid id)
            {
                try
                {
                    return await contexto.Carteira.FirstOrDefaultAsync(carteira => carteira.Id.Equals(id))
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public async Task<bool> AdicionarInvestimento(uint ProdutoId,Guid CarteiraId,decimal valor)
            {
                try
                {
                    var produto = await this.GetProdutoByIdAsync(ProdutoId).ConfigureAwait(false);
                    var carteira = await this.GetCarteiraByNomeAsync(CarteiraId);
                    var guid = Guid.NewGuid();
                    var invest = new Investimento(guid, valor, produto, carteira);
                    await contexto.Investimento.AddAsync(invest).ConfigureAwait(false);
                    await contexto.SaveChangesAsync().ConfigureAwait(false);
                    return await this.ExistInvestimentoByIdAsync(guid).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            public async Task<bool> ExistInvestimentoByIdAsync(Guid id)
            {
                try
                {
                    return await contexto.Investimento.AsNoTracking()
                        .AnyAsync(investimento => investimento.Id.Equals(id)).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public async Task<Investimento> GetInvestimentoByIdAsync(Guid id)
            {
                try
                {
                    return await contexto.Investimento
                        .FirstOrDefaultAsync(investimento => investimento.Id.Equals(id))
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }



            public async Task<List<Produto>> GetProdutosAsync()
            {
                return await contexto.Produto.AsNoTracking().OrderByDescending(produto => produto.Nome).ToListAsync().ConfigureAwait(false);
            }
            public async Task<List<Investimento>> GetInvestimentosAsync(Guid CarteiraId)
            {
                return await contexto.Investimento
                    .Where(investimento => investimento.Carteira.Id.Equals(CarteiraId) && investimento.DataRetornado == null)
                    .OrderByDescending(investimento => investimento.DataInvestimento).ToListAsync().ConfigureAwait(false);
            }
        }
    }
