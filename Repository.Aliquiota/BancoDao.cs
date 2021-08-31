using Domain.Aliquiota;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Aliquiota
{
    public class BancoDao : IRepository<Banco>
    {
        private readonly Context ctx;
        
        public BancoDao(Context context)
        {
            ctx = context;
        }

        public bool Cadastrar(Banco banco) 
        {
            bool Aux = true;
           
            if (banco.Nome.Equals(""))
            {
                Aux = false;
               
            }

            if (banco.Numero.Equals(""))
            {
                Aux = false;
                
            }

            if (BuscaBancoNmr(banco.Numero) != null)
            {
               
                Aux = false; 
            }

            if (Aux == true)
            {
                ctx.Bancos.Add(banco);
                ctx.SaveChanges();
                return true;
            }

            else
            { 
                return false; 
            }
        }
       public List<Banco> Listar()
        {
            return ctx.Bancos.ToList();
        }


        public Banco BuscarPorId(int id) 
        {
            return ctx.Bancos.Find(id);
        }

        public Banco BuscaBancoNmr(int nmr)
        {
            return ctx.Bancos.FirstOrDefault(n => n.Numero.Equals(nmr));
        }


    }
}
