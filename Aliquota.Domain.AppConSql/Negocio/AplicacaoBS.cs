using Aliquota.Domain.AppConSql.Contexto;
using Aliquota.Domain.AppConSql.Repositorio;
using Aliquota.Domain.AppConSql.UtilClass;

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace Aliquota.Domain.AppConSql.Negocio
{
   class AplicacaoBS
   {
      private readonly AplicacaoRepositorio dao;
      public AplicacaoBS( ) 
      {
         dao = new AplicacaoRepositorio();
      } 

      public IEnumerable<Aplicacao> getAll()
      {
         return dao.getAll;
      }

      public Aplicacao GetById(int id)
      {
         return dao.GetById(id);
      }

      public void save(Aplicacao aplicacao)
      {
         dao.Save(aplicacao);
      }

      public void saveChanges()
      {
         dao.SaveChanges();
      }



      public void Update(Aplicacao aplicacao)
      {
         dao.Update(aplicacao);
      }

      public DateTime getDataRandom()
      {
         Random random = new Random();
         return DateTime.Now.AddDays(((random.Next(3) * 370) + 200) * -1);
      }

      public void popularAplicacoes()
      {
         DateTime dtMov;
         decimal  valor;
         int      num;

         Random random = new Random();

         ClienteBS clienteBS = new ClienteBS();
         dao.TruncateTable();
         saveChanges();

         foreach (Cliente cli in clienteBS.getAll() )
         {
            num = random.Next(4) + 3;
            for (int i = 1; i <= num; i++)
            {
               dtMov = getDataRandom();
               valor = random.Next(2000) + 500;
               save(new Aplicacao { DataMov = dtMov, ValorAplicado = valor, ClienteId = cli.ClienteId, DataAtual = dtMov, ValorAtual = valor });
            }
            saveChanges();
         }
      }


      public void atualizarAplicacoes()
      {

         int          qtde;

         qtde = Count();
         if (qtde == 0)
         {
            popularAplicacoes();
         }

         foreach (Aplicacao aplicacao in getAll())
         {
            atualizarAplicacao(aplicacao);
          
         }
         saveChanges();
      }


      public void atualizarAplicacao (Aplicacao aplicacao)
      {
         DateTime ultimaAtual;
         decimal valorReal;
         Rendimento rendimento;
         RendimentoBS rendimentoBS;

         rendimentoBS = new RendimentoBS();

         ultimaAtual = aplicacao.DataAtual;
         valorReal = aplicacao.ValorAtual;
         if (valorReal > 0)
         {
            while (ultimaAtual < DateTime.Now)
            {
               rendimento = rendimentoBS.GetRendimentoByData(ultimaAtual);

               if (rendimento != null)
               {
                  valorReal = valorReal + (valorReal * rendimento.Percentual / ((decimal)100.00));
               }
               ultimaAtual = ultimaAtual.AddDays(1);
            }
            aplicacao.DataAtual = ultimaAtual.AddDays(-1);
            aplicacao.ValorAtual = valorReal;
            Update(aplicacao);
         }
      }


      public int Count()
      {
         return dao.Count();
      }


      public decimal getValorIR(DateTime inicioAplicacao, DateTime dataResgate, decimal lucro)
      {
         decimal  ir = 0;
         int dias;
         int meses;
         int anos;

         Util.DiferencaEntreDatas(inicioAplicacao, dataResgate, out dias, out meses, out anos);


         if (anos <= 1)
         {
            ir = (lucro * (decimal)22.5) / (decimal)100.00;
         }
         else
         {
            if (anos <= 2)
            {
               ir = (lucro * (decimal)18.5) / (decimal)100.00;
            }
            else
            {
               ir = (lucro * (decimal)15) / (decimal)100.00;
            }
         }
         
         return decimal.Round(ir, 2, MidpointRounding.AwayFromZero); 

      }




   }
}
