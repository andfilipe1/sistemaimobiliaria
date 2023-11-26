using AdmBoaFe.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdmBoaFe.Data.Mappings
{
    public class CondominioMapping : IEntityTypeConfiguration<Condominio>
    {
        public void Configure(EntityTypeBuilder<Condominio> builder)
        {
            builder.ToTable("Condominios");

            // Chave Primária
            builder.HasKey(c => c.Id);

            // Propriedades
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Descricao)
                .HasColumnType("text");

            builder.Property(c => c.DataFundacao)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(c => c.NumeroBlocos)
                .IsRequired();

            builder.Property(c => c.NumeroTotalUnidades)
                .IsRequired();

            builder.Property(c => c.AreaTotal)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            builder.Property(c => c.TaxaCondominioMensal)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            builder.Property(c => c.ContatoSindico)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.ContatoAdministracao)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Documento)
                .IsRequired()
                .HasColumnType("varchar(14)");

            // Relacionamento com Logradouro
            builder.HasOne(c => c.Logradouro)
                .WithMany() // Se Logradouro não tiver uma coleção de Condominios
                .HasForeignKey(c => c.LogradouroId);

            // Relacionamento com Imovel
            builder.HasMany(c => c.Imovel)
                .WithOne(i => i.Condominio)
                .HasForeignKey(i => i.CondominioId);
        }
    }
}
