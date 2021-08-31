using Domain.Aliquiota;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Aliquiota
{
    public class ContaDAO : IRepository<Conta>
    {
        private readonly Context ctx;
        public ContaDAO(Context context)
        {
            ctx = context;
        }


        public bool Cadastrar(Conta c)
        {
            bool Aux_BL = true;

            if (BuscarContaNmr(c.NumeroConta) != null || c.NumeroConta == null)
            {
                Aux_BL = false;
            }
            
            if (BuscarContaCpf(c.Cliente.Cpf) != null || c.Cliente.Cpf == null)
            {
                Aux_BL = false;
            }

            if (c.Senha == null)
            {
                Aux_BL = false;
            }
            if (c.Banco == null)
            {
                Aux_BL = false;
            }

            if(Aux_BL == true){

                ctx.Contas.Add(c);
                ctx.SaveChanges();
            }

            return Aux_BL;
        }


        public List<Conta> Listar()
        {
            return ctx.Contas.Include(c => c.Cliente).Include(b => b.Banco).ToList();
        }

        public Conta BuscarPorId(int id)
        {
            return ctx.Contas.Find(id);
        }

        public bool ValidarAcesso(Conta c)
        {
            var ContaNmr = BuscarContaNmr(c.NumeroConta);
          
            if (ContaNmr != null)
            {
                
                if (ContaNmr.Senha == c.Senha)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                

            }else
            {
                return false;
            }
        }

        public Conta BuscarContaNmr(int nmr)
        {
            return ctx.Contas.Include(b => b.Banco).FirstOrDefault(x => x.NumeroConta.Equals(nmr));
        }

        public Conta BuscarContaCpf(int cpf)
        {
            return ctx.Contas.FirstOrDefault(x => x.Cliente.Cpf.Equals(cpf));
        }

        public int RetornaBanco(int nmr)
        {
            var conta = BuscarContaNmr(nmr);
            return conta.Banco.Numero;
        }

    }
}
