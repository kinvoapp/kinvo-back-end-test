using Aliquota.Domain.Entities;
using Microsoft.VisualBasic;
using System;

namespace Aliquota.Domain.Services
{
    public class AliquotaService : IAliquotaService
    {
        public Aplicacao DoAplicar(Produto produto, Cliente cliente, DateTime data, decimal valor)
        {
            if (valor > decimal.Zero)
            {
                Aplicacao aplicacao = new Aplicacao { Cliente = cliente, Produto = produto, Data = data, ValorAplicado = valor };
                return aplicacao;
            }
            return null;
        }

        public decimal DoCalcularIR(DateTime dataI, DateTime dataF, decimal baseIR)
        {
            if (dataF < dataI)
                return decimal.Zero;
            long meses = DateAndTime.DateDiff(DateInterval.Month, dataI, dataF);
            decimal aliquota = 0;
            if (meses <= 12)
                aliquota = 22.5m;
            else if (meses > 12 && meses <= 24)
                aliquota = 18.5m;
            else if (meses > 24)
                aliquota = 15m;
            return decimal.Round(baseIR * aliquota / 100m, 2);
        }

        public void DoResgatar(Aplicacao aplicacao, DateTime data)
        {
            if(aplicacao != null && aplicacao.Data <= data && !aplicacao.IsResgado)
            {
                aplicacao.IR = DoCalcularIR(aplicacao.Data, data, aplicacao.Rendimento);
                aplicacao.DataResgate = data;
            }
        }

        public static Cliente Clientefactory()
        {
            return new Cliente { Id = 1, Nome = "Jefferson Pereira" };
        }

        public static Produto Produtofactory()
        {
            return new Produto { Id = 1, Descricao = "Um determinado produto" };
        }
    }
}
