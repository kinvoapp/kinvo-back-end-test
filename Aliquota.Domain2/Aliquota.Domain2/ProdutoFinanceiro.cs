using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain
{
    class ProdutoFinanceiro : IProdutoFinanceiro
    {
        public Cliente cliente = new Cliente();
        public int tempoTotalAplicacao { get; set; }

        public ProdutoFinanceiro()
        {
            this.cliente = new Cliente();
            this.tempoTotalAplicacao = 0;
        }

        public ProdutoFinanceiro(string nome, int cpf)
        {
            this.cliente = new Cliente(nome, cpf);
            this.tempoTotalAplicacao = 0;
        }

        public int calcularTempoAplicacao(Date inicial, Date final)
        {
            this.tempoTotalAplicacao = (((final.ano - inicial.ano) * 12) + (final.mes - inicial.mes));
            if (inicial.ano > final.ano)
            {
                Console.WriteLine("Data inválida");
                return this.tempoTotalAplicacao;
            }
            else if (inicial.ano == final.ano && final.mes < inicial.mes)
            {
                Console.WriteLine("Valores inválidos");
                return this.tempoTotalAplicacao;
            }
            else
            {
             
                return this.tempoTotalAplicacao;
            }
        }

        public double tratarResgateCliente(double valor)
        {
            var saldoCliente = cliente.getValorInvestido();
            
            if (saldoCliente < valor)
            {
                Console.WriteLine("Valor de resgate maior que o saldo");
                return 0;
            }

            if (this.tempoTotalAplicacao < 12)
            {
                var valorDescontado = valor + (cliente.getLucro() * 0.225);
                cliente.resgatar(valorDescontado);
                return valorDescontado;
            }
            else if (this.tempoTotalAplicacao >= 12 && tempoTotalAplicacao <= 24)
            {
                var valorDescontado = valor + (cliente.getLucro() * 0.185);
                cliente.resgatar(valorDescontado);
                return valorDescontado;
            }
            else
            {
                var valorDescontado = valor + cliente.getLucro() * 0.15;
                cliente.resgatar(valorDescontado);
                return valorDescontado;
            }
        }

        public double tratarDepositoCliente(double valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Valor inválido.");
                return 0;
            }
            else
            {
                cliente.adicionarValorInvestido(valor);
                Console.WriteLine("Deposito efetuado com sucesso.");
                return valor;
            }
        }
        public void novaDataIncialAplicacao(int mes, int ano)
        {
            cliente.inserirDataIncialAplicacao(mes, ano);
        }

        public void novaDataFinalAplicacao(int mes, int ano)
        {
            cliente.inserirDataFinalAplicacao(mes, ano);
        }

        public int getTempoTotalAplicacao()
        {
            return this.tempoTotalAplicacao;
        }
    }
}
