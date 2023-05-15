using CadastroCliente.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Map
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasConversion(c => c.ToString(), c => c)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Email)
                .HasConversion(c => c.ToString(), c => c)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Telefone)
               .HasConversion(c => c.ToString(), c => c)
               .IsRequired()
               .HasColumnName("Telefone")
               .HasColumnType("varchar(11)");

            builder.Property(c => c.Cidade)
                .HasConversion(c => c.ToString(), c => c)
                .IsRequired()
                .HasColumnName("Cidade")
                .HasColumnType("varchar(100)");

        }
    }
}


