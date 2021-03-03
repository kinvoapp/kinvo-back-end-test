using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Web.Models
{
  public class AplicacaoDataContexts : DbContext
  {
    public DbSet<Aplicacao> Aplicacoes { get; set; }

    public AplicacaoDataContexts(DbContextOptions<AplicacaoDataContexts> options)
        : base(options)
    {
      Database.EnsureCreated();
    }
  }
}
