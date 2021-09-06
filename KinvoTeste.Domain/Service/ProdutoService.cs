using KinvoTeste.Data;
using KinvoTeste.Domain.Validations;
using KinvoTeste.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KinvoTeste.Domain.Service
{
    public class ProdutoService
    {
        private ProdutoRepository Repository { get; set; }

        public ProdutoService()
        {
            Repository = new ProdutoRepository();
        }

        public int Add(Produto produto)
        {
            new ProdutoAplicarValorValidation().Validate(produto);

            produto.Usuario.Contas.First().Saldo -= produto.ValorInvestido;
            var contaRepository = new ContaRepository();
            contaRepository.Atualizar(produto.Usuario.Contas.First());

            produto.UsuarioId = produto.Usuario.Id;
            return Repository.Add(produto);
        }

        public List<Resgate> Resgatar(int idUsuario, DateTime dataResgate, bool simular = false)
        {
            var usuarioRepository = new UsuarioRepository();
            var usuario = usuarioRepository.Get(idUsuario);

            if (usuario.Produtos != null)
            {
                foreach (var item in usuario.Produtos)
                {
                    item.CalcularResgate(dataResgate);
                }
            }

            var produtosvViaveis = usuario.Produtos.Where(x => x.Resgate != null);

            if(!simular && produtosvViaveis.Count() > 0)
            {
                usuario.Contas.First().Saldo += produtosvViaveis.Sum(x => x.Resgate.ValorLiquido);
                var contaRepository = new ContaRepository();
                contaRepository.Atualizar(usuario.Contas.First());

                foreach (var item in produtosvViaveis)
                {
                    Repository.Delete(item.Id);
                }
            }

            return produtosvViaveis.Select(x => x.Resgate).ToList();
        }
    }
}
