using KinvoTeste.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KinvoTeste.Data.Config
{
    public class ProdutoConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Ignore(x => x.Usuario);
            builder.Ignore(x => x.ValorBruto);
            builder.Ignore(x => x.Resgate);
        }
    }
}
