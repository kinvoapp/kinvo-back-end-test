using System;
using src.Database;
using src.Models;

namespace src.Repositories
{
    public class AtivoRepository : BaseRepository<Ativo>
    {
      /// <summary>
      /// Método construtor
      /// </summary>
      /// <param name="kinvoContext">Contexto usado no service</param>
      public AtivoRepository(KinvoDbContext kinvoContext) : base(kinvoContext) { }

    }
}
