using AdmBoaFe.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdmBoaFe.Data.Mappings
{
    public class ProprietarioMapping : IEntityTypeConfiguration<Proprietario>
    {
        public void Configure(EntityTypeBuilder<Proprietario> builder)
        {
            builder.ToTable("Proprietarios");

            // Chave Primária
            builder.HasKey(p => p.Id);

            // Propriedades
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.TipoProprietario)
                .IsRequired()
                .HasColumnType("int");

            // Relacionamento com Logradouro
            builder.HasOne(p => p.Logradouro)
                .WithMany() // Se Logradouro não tiver uma coleção de Proprietarios
                .HasForeignKey(p => p.LogradouroId);

            // Relacionamento com Imoveis
            builder.HasMany(p => p.Imoveis)
                .WithOne(i => i.Proprietario)
                .HasForeignKey(i => i.ProprietarioId);
        }
    }
}
