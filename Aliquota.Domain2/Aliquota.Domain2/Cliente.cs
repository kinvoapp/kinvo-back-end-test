using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain
{
    public class Cliente : ICliente
    {
        private string nome;
        private int cpf;
        private double valorInvestido;
        private double lucro;
        private Date dataIncialAplicacao;
        private Date dataFinalAplicacao;

        public Cliente()
        {
            this.nome = "";
            this.cpf = 0;
            this.valorInvestido = 0;
            this.lucro = 0;
        }
        public Cliente(string nome, int cpf)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.valorInvestido = 0;
            this.lucro = 0;
        }

        public Cliente(string nome, int cpf, double valorInvestido)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.valorInvestido = valorInvestido;
        }

        public Cliente(string nome, int cpf, double valorInvestido, double lucro)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.valorInvestido = valorInvestido;
            this.lucro = lucro;
        }

        public void adicionarValorInvestido(double valor)
        {
            this.valorInvestido += valor;
        }

        public void resgatar(double valorDescontado)
        {
            this.valorInvestido -= valorDescontado;
        }

        public void inserirDataIncialAplicacao(int mes, int ano)
        {
            this.dataIncialAplicacao = new Date(mes, ano);
        }

        public void inserirDataFinalAplicacao(int mes, int ano)
        {
            this.dataFinalAplicacao = new Date(mes, ano);
        }

        public string getNome()
        {
            return this.nome;
        }

        public void setNome(string novoNome)
        {
            this.nome = novoNome;
        }

        public int getCpf()
        {
            return this.cpf;
        }

        public void setCpf(int novoCpf)
        {
            this.cpf = novoCpf;
        }

        public double getValorInvestido()
        {
            return this.valorInvestido;
        }

        public string getValorInvestidoMonetario()
        {
            return this.valorInvestido.ToString("C");
        }

        public void setValorInvestido(double valor)
        {
            this.valorInvestido = valor;
        }

        public double getLucro()
        {
            return this.lucro;
        }

        public void setLucro(double valor)
        {
            this.lucro = valor;
        }

        public Date getDataInicialAplicacao()
        {
            return this.dataIncialAplicacao;
        }

        public Date getDataFinalAplicacao()
        {
            return this.dataFinalAplicacao;
        }
    }
}
