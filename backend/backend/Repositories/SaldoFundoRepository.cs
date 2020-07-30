using System;
using src.Database;
using src.Models;

namespace src.Repositories
{
    public class SaldoFundoRepository : BaseRepository<SaldoFundo>, ISaldoFundoRepository
    {
      /// <summary>
      /// Método construtor
      /// </summary>
      /// <param name="kinvoContext">Contexto usado no service</param>
      public SaldoFundoRepository(KinvoDbContext kinvoContext) : base(kinvoContext) { }

    }
}
