namespace Aliquota.Domain
{
    public class InformacaoFiscal
    {
        /// <summary>
        /// Rendimento da Aplicação
        /// </summary>
        public decimal RedimentoAplicacao { get; set; }
        /// <summary>
        /// Aliquota IR
        /// </summary>
        public decimal Aliquota { get; set; }
        /// <summary>
        /// Valor Retido na Fonte
        /// </summary>
        public decimal ValorRetido { get; set; }

        public decimal Saque { get; set; } 
        /// <summary>
        /// Descriç~çao do Produto
        /// </summary>
        public Produto Produto { get; set; }

    }
}
