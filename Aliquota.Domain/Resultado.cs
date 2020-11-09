namespace Aliquota.Domain
{
    public sealed class Resultado<T>
    {
        public bool Sucesso { get; }
        public T Dados { get;  }
        public string MensagemDeErro { get;  }

        public Resultado(T dados)
        {
            Sucesso = true;
            Dados = dados;
            MensagemDeErro = null;
        }

        public Resultado(bool sucesso, string erro)
        {
            Sucesso = sucesso;
            MensagemDeErro = erro;
        }

        public static Resultado<T> Erro(string mensagemDeErro)
        {
            return new Resultado<T>(false, mensagemDeErro);
        }

        public static Resultado<T> OK(T dados)
        {
            return new Resultado<T>(dados);
        }


    }
}
