using System;
using src.Database;
using src.Models;

namespace src.Repositories
{
    public class AplicacaoFundoRepository : BaseRepository<AplicacaoFundo>, IAplicacaoFundoRepository
    {
      /// <summary>
      /// Método construtor
      /// </summary>
      /// <param name="kinvoContext">Contexto usado no service</param>
      public AplicacaoFundoRepository(KinvoDbContext kinvoContext) : base(kinvoContext) { }

    }
}
