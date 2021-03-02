
using Aliquota.Domain.AggregatesModel.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aliquota.Infrastructure.EntityConfigurations
{
    class UsuarioTypeConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> usuarioConfiguration)
        {
            usuarioConfiguration.HasKey(o => o.Id);

            usuarioConfiguration
                .Property<string>("nome")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .IsRequired(true);
        }
    }
}
