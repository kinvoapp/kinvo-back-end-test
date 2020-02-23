using Aliquota.Domain.Excecao;
using System;
using System.Text;

namespace Aliquota.Domain
{
    public class OperadorIR
    {
        public Cliente cliente { get; set; }
        public Produto produto { get; set; }
        public DateTime dataAplicacao { get; set; }
        public double valorAplicado { get; set; }
        public double impostoRenda { get; set; }

        public OperadorIR(Cliente cliente, Produto produto)
        {
            this.cliente = cliente;
            this.produto = produto;
        }

        public void Aplicar(double valorAplicado)
        {
            if (cliente == null || produto == null)
            {
                throw new ExcecaoNegocio("As entidades Cliente e Produto precisam existir para acontecer uma aplicação");
            }

            if (valorAplicado <= 0)
            {
                throw new ExcecaoNegocio("O valor da aplicação não pode ser menor ou igual a zero");
            }

            this.cliente.produtos.Add(produto);

            this.valorAplicado = valorAplicado;
            this.cliente.patrimonio += valorAplicado;

            dataAplicacao = DateTime.Now;
        }

        public string Resgatar(DateTime dataResgate)
        {
            if (valorAplicado == 0)
            {
                throw new ExcecaoNegocio("Não existe valor aplicado para resgate");
            }

            if (dataResgate.Date <= dataAplicacao.Date)
            {
                throw new ExcecaoNegocio("A data de resgate não pode ser menor ou igual a data da aplicação");
            }

            var totalDias = (int)dataResgate.Subtract(dataAplicacao).TotalDays;
            var juros = CalcularJuros(totalDias);
            var meses = (int)Math.Truncate((decimal)totalDias / 30);

            var montante = CalcularMontante(meses);
            var valorFinal = Math.Round(montante - valorAplicado, 3);

            impostoRenda = Math.Round(valorFinal * juros, 3);
            cliente.patrimonio += Math.Round(valorFinal - impostoRenda, 3);

            var mensagem = new StringBuilder();
            mensagem.AppendLine($"O valor aplicado foi R$ {valorAplicado}");
            mensagem.AppendLine($"O valor líquido dos lucros é de R$ {valorFinal - (valorFinal * juros)}");
            mensagem.AppendLine($"O valor total do imposto de renda na aplicação foi de R$ {impostoRenda}");

            return mensagem.ToString();
        }

        private double CalcularJuros(int diferencaDias)
        {
            if (diferencaDias >= 730)
            {
                return 0.15;
            }
            else if (diferencaDias > 365 && diferencaDias < 730)
            {
                return 0.185;
            }

            return 0.225;
        }

        private double CalcularMontante(int tempo)
        {
            return Math.Round(valorAplicado * Math.Pow((1 + produto.taxaRendimento), tempo), 3);
        }
    }
}
