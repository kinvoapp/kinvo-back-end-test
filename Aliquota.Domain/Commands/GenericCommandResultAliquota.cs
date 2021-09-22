using System;
using Aliquota.Domain.Commands.Contracts;

namespace Aliquota.Domain.Commands
{
    public class GenericCommandResultAliquota : ICommandResult
    {
        public GenericCommandResultAliquota()
        {

        }
        public GenericCommandResultAliquota(bool sucesso, string titulo, string mensagem, object valorResgatado)
        {
            Sucesso = sucesso;
            Titulo = titulo;
            Mensagem = mensagem;
            ValorResgatado = valorResgatado;
        }

        public bool Sucesso { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public object ValorResgatado { get; set; }
    }
}
