using Aliquiota.CrossCutting;
using System;

namespace Aliquota.Domain
{
    public class Aplicacao : EntityBase
    {
        public int UsuarioId { get; set; }

        public DateTime DataRegistro { get; set; }

        public DateTime? DataResgate { get; set; }

        public double RentabilidadeDiaria { get; set; }

        public double ValorAplicado { get; set; }

        public double ValorBruto { get => ValorAplicado.CalcularJurosCompostos(RentabilidadeDiaria, DataRegistro, DataResgate); }

        public double ValorLiquido { get => ValorBruto.CalcularIR(ValorAplicado, DataRegistro, DataResgate); }

        public double AliquotaAplicada { get => DataRegistro.CalcularAliquotaIR(DataResgate); }


        public Aplicacao(double rentabilidade, double valor, int usuarioID)
        {
            if (rentabilidade <= 0)
                throw new ApplicationException("A rentabilidade deve ser maior que 0 (zero)");
            if (valor <= 0)
                throw new ApplicationException("O valor da aplicação deve ser maior que 0 (zero)");

            DataRegistro = DateTime.Now;
            RentabilidadeDiaria = rentabilidade;
            ValorAplicado = valor;
            UsuarioId = usuarioID;
        }

        public Aplicacao()
        {
        }

        public void Resgatar(DateTime? data = null)
        {
            if (DataResgate != null)
                throw new ApplicationException("Esta aplicação já foi resgatada");

            if (data == null)
                data = DateTime.Now;

            if (data < DataRegistro)
                throw new ApplicationException($"A data de resgaste deve ser maior ou igual a {DataRegistro.ToString("dd/MM/yyyy")}");

            DataResgate = data;

        }
    }
}
