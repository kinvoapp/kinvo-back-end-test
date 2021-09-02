using Aliquota.Domain.Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aliquota.Domain.Repository.Implementacao.Context
{
    public class BaseDeDados
    {
        private AliquotaDbContext _context;

        public BaseDeDados(AliquotaDbContext context)
        {
            _context = context;
        }

        public void Gerar()
        {
            if (_context.TipoProdutos.Any() && _context.SituacaoProdutos.Any())
            {
                return;
            }
            var s1 = new SituacaoProduto() { Situacao = "Não movimentado" };
            var s2 = new SituacaoProduto() { Situacao = "Movimentado" };
            var s3 = new SituacaoProduto() { Situacao = "Bloqueado" };

            var tp1 = new TipoProduto() { NomeTipoProduto = "Poupança", Rentabilidade = 1.05m };
            var tp2 = new TipoProduto() { NomeTipoProduto = "Previdencia privada", Rentabilidade = 1.15m };
            var tp3 = new TipoProduto() { NomeTipoProduto = "Tesouro direto", Rentabilidade = 1.10m };
            var tp4 = new TipoProduto() { NomeTipoProduto = "Bovespa", Rentabilidade = 1.30m };

            _context.TipoProdutos.AddRange(tp1, tp2, tp3, tp4);
            _context.SituacaoProdutos.AddRange(s1, s2, s3);

            _context.SaveChanges();

        }
    }
}
