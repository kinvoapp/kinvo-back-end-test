using Domain.Aliquiota;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Aliquiota
{
    public class ProdutoDAO : IRepository<Produto>
    {
        private readonly Context ctx;
        public ProdutoDAO(Context context)
        {
            ctx = context;
        }

        public List<Produto> Listar()
        {
            return ctx.Produtos.Include(x => x.Banco).ToList();
        }

        public List<Produto> ProdutoBanco(int banco)
        {
            return ctx.Produtos.Include(x => x.Banco).Where(b => b.Banco.Numero.Equals(banco)).ToList();
        }

        public bool Cadastrar(Produto prod)
        {
            bool Aux_BL = true;
            if (prod.Ano_Maior_IR == 0 || prod.Ano_Maior_IR == null)
            {
                Aux_BL = false;
            }

            if (prod.Ano_Menor_IR == 0 || prod.Ano_Menor_IR == null)
            {
                Aux_BL = false;
            }

            if (prod.Banco == null)
            {
                Aux_BL = false;
            }

            if (prod.Nome == "" || prod.Nome == null)
            {
                Aux_BL = false;
            }

            if (prod.Rendimento == 0 || prod.Rendimento == null)
            {
                Aux_BL = false;
            }

            if (prod.Taxa_Entre_IR == 0 || prod.Taxa_Entre_IR == null)
            {
                Aux_BL = false;
            }

            if (prod.Taxa_Menor_IR == 0 || prod.Taxa_Menor_IR == null)
            {
                Aux_BL = false;
            }

            if (prod.Taxa_Maior_IR == 0 || prod.Taxa_Maior_IR == null)
            {
                Aux_BL = false;
            }

            if (prod.Tempo_Rendimento_Dias == 0 || prod.Tempo_Rendimento_Dias == null)
            {
                Aux_BL = false;
            }
            if (Aux_BL == true)
            {
                ctx.Produtos.Add(prod);
                ctx.SaveChanges();
            }

            
            return Aux_BL;
        }
        public Produto BuscarPorId(int id)
        {
            return ctx.Produtos.Find(id);
        }

        public void Remover(int id)
        {
            ctx.Produtos.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public void Alterar(Produto p)
        {
            ctx.Produtos.Update(p);
            ctx.SaveChanges();
        }

    }
    
}
