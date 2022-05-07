using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Aliquota.App.ViewModels;

namespace Aliquota.App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //public DbSet<Aliquota.App.ViewModels.ProdutoViewModel> ProdutoViewModel { get; set; }
        //public DbSet<Aliquota.App.ViewModels.PosicaoViewModel> PosicaoViewModel { get; set; }
    }
}
