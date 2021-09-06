using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Notifications
{
    public class Notify
    {
        public Notify()
        {
            Notificacoes = new List<Notify>();
        }

        [NotMapped]
        public string NomePropriedade { get; set; }

        [NotMapped]
        public string Mensagem { get; set; }

        [NotMapped]
        public List<Notify> Notificacoes;


        //VALIDAÇÃO DOS CAMPOS NA VIEW DE CONSULTA COM MENSAGENS PERSONALIZADAS
        public bool ValidarRendaAplicada(double valor, string nomePropriedade)
        {
            if (valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notificacoes.Add(new Notify
                {
                    Mensagem = "A Renda não pode ser menor que 0!",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            return true;
        }

        public bool ValidarLucro(double valor, string nomePropriedade)
        {
            if (valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notificacoes.Add(new Notify
                {
                    Mensagem = "O Lucro não pode ser menor que 0!",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            return true;
        }

        public bool ValidarDataAplicacao(DateTime valor, string nomePropriedade)
        {
            if (valor == DateTime.MinValue || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notificacoes.Add(new Notify
                {
                    Mensagem = "A Data de Aplicação deve ser informada!",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            return true;
        }

        public bool ValidarDataResgate(DateTime valor, string nomePropriedade)
        {
            if (valor == DateTime.MinValue || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notificacoes.Add(new Notify
                {
                    Mensagem = "A Data de Resgate deve ser informada!",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            return true;
        }

        public bool ValidarDataResgateSobreAplicacao(DateTime valor, DateTime aplicacao, string nomePropriedade)
        {
            int data = DateTime.Compare(aplicacao, valor);
            if (data > 0)
            {
                Notificacoes.Add(new Notify
                {
                    Mensagem = "Data de Resgate não pode ser menor que a Data de Aplicação!",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            return true;
        }
    }
}
