using KinvoTeste.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KinvoTeste.Data.Config
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasMany(x => x.Contas).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Produtos).WithOne().OnDelete(DeleteBehavior.Cascade);

            builder.Ignore(x => x.Token);
        }
    }
}
