using System;

namespace Aliquota.Domain.Entities
{
    public class AplicacaoRF
    {
        private const int TOTAL_DIAS_RENDIMENTO_ANO = 261;
        private const int DIAS_SEMANA = 7;

        private const decimal ALIQUOTA_ATE_1_ANO = 22.5M;
        private const decimal ALIQUOTA_ACIMA_1_ATE_2_ANOS = 18.5M;
        private const decimal ALIQUOTA_ACIMA_2_ANOS = 15M;

        private const string MSG_ERRO_PERIODO = "A data de resgate não pode ser anterior à data da aplicação";

        private DateTime? _dataAplicacao;
        private DateTime? _dataResgate;
        private decimal _valorAplicado;

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataAplicacao
        {
            get
            {
                return _dataAplicacao;
            }
            set
            {
                _dataAplicacao = NovoPeriodoValido(value, _dataResgate) ? value : throw new ArgumentException(MSG_ERRO_PERIODO);
            }
        }
        public DateTime? DataResgate
        {
            get
            {
                return _dataResgate;
            }
            set
            {
                _dataResgate = NovoPeriodoValido(_dataAplicacao, value) ? value : throw new ArgumentException(MSG_ERRO_PERIODO);
            }
        }
        public decimal ValorAplicado
        {
            get
            {
                return _valorAplicado;
            }
            set
            {
                _valorAplicado = value >= 0.01M ? value : throw new ArgumentException("O valor aplicado não pode ser menor ou igual a 0.00");
            }
        }
        public decimal TaxaJurosAnual { get; set; }
        public decimal AliquotaIR
        {
            get
            {
                int lAnosArredPraCima = CalcAnosRentaveisCompletos();
                if (DataResgate.Value.Month != DataAplicacao.Value.Month || DataResgate.Value.Day != DataAplicacao.Value.Day)
                    lAnosArredPraCima++;

                if (lAnosArredPraCima <= 1)
                    return ALIQUOTA_ATE_1_ANO ;
                else if (lAnosArredPraCima == 2)
                    return ALIQUOTA_ACIMA_1_ATE_2_ANOS;
                else
                    return ALIQUOTA_ACIMA_2_ANOS;
            }
        }
        public decimal RendimentoTotal {
            get
            {
                int lDias = CalcDiasRentaveisRestantes();
                double lFatorDiario = Math.Pow((double)(1 + (TaxaJurosAnual / 100)), (1 / (double)TOTAL_DIAS_RENDIMENTO_ANO));

                double lFatorEfetivo = Math.Pow((double)(1 + (TaxaJurosAnual / 100)), CalcAnosRentaveisCompletos());
                lFatorEfetivo *= Math.Pow(lFatorDiario, lDias);  
                return ValorAplicado * (decimal)(lFatorEfetivo - 1);

            }
        }
        public decimal IRRecolhido 
        {
            get
            {
                return RendimentoTotal * AliquotaIR / 100;
            }
        }
        private int CalcAnosRentaveisCompletos()
        {
            var lAnosCompletos = DataResgate.Value.Year - DataAplicacao.Value.Year;
            if (lAnosCompletos > 0
                && (DataResgate.Value.Month < DataAplicacao.Value.Month
                    || DataResgate.Value.Month == DataAplicacao.Value.Month && DataResgate.Value.Day < DataAplicacao.Value.Day))
            {
                lAnosCompletos--;
            }
            return lAnosCompletos;

        }
        private int CalcDiasRentaveisRestantes()
        {
            int lAnosCompletos = CalcAnosRentaveisCompletos();

            DateTime lPonteiroData = new DateTime(DataAplicacao.Value.Year + lAnosCompletos, DataAplicacao.Value.Month, DataAplicacao.Value.Day + 1);

            int lQtdSemanas = (int)(DataResgate.Value - lPonteiroData).TotalDays / DIAS_SEMANA;
            int lDiasRentaveis = 5 * lQtdSemanas;

            lPonteiroData = lPonteiroData.AddDays(lQtdSemanas * DIAS_SEMANA);

           while (DateTime.Compare(lPonteiroData,DataResgate.Value) <=   0)
           {
                if (lPonteiroData.DayOfWeek == DayOfWeek.Saturday)
                {
                    lPonteiroData = lPonteiroData.AddDays(2);
                }
                else if (lPonteiroData.DayOfWeek == DayOfWeek.Sunday)
                {
                    lPonteiroData = lPonteiroData.AddDays(1);
                }
                else
                {
                    lDiasRentaveis++;
                    lPonteiroData = lPonteiroData.AddDays(1);
                }

            }
            return lDiasRentaveis;

        }
        private bool NovoPeriodoValido(DateTime? pInicio, DateTime? pFinal)
        {
            if (pInicio.HasValue && pFinal.HasValue && DateTime.Compare(pInicio.Value, pFinal.Value) > 0)
                return false;
            else
                return true;
        }

    }

}