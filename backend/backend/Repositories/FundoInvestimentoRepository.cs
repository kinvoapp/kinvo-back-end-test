using System;
using src.Database;
using src.Models;

namespace src.Repositories
{
    public class FundoInvestimentoRepository : BaseRepository<FundoInvestimento>, IFundoInvestimentoRepository
    {
        /// <summary>
        /// Método construtor
        /// </summary>
        /// <param name="kinvoContext">Contexto usado no service</param>
        public FundoInvestimentoRepository(KinvoDbContext kinvoContext) : base(kinvoContext) { }

    }
}
