using AdmBoaFe.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdmBoaFe.Data.Mappings
{
    public class InquilinoMapping : IEntityTypeConfiguration<Inquilino>
    {
        public void Configure(EntityTypeBuilder<Inquilino> builder)
        {
            builder.ToTable("Inquilinos");

            // Chave Primária
            builder.HasKey(i => i.Id);

            // Propriedades
            builder.Property(i => i.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(i => i.TipoInquilino)
                .IsRequired()
                .HasColumnType("int");

            builder.HasOne(i => i.Logradouro)
                .WithMany() 
                .HasForeignKey(i => i.LogradouroId);

            builder.HasOne(i => i.Imovel)
                .WithOne() 
                .HasForeignKey<Imovel>(i => i.InquilinoId); 
        }
    }
}
