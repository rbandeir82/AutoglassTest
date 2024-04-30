using AutoglassTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoglassTest.Infra.Data.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Descricao)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Descricao")
                .HasColumnType("varchar(255)");

            builder.Property(prop => prop.Situacao)
                .HasConversion(prop => prop.ToString().ToCharArray()[0], prop => prop)
                .IsRequired()
                .HasColumnName("Situacao")
                .HasColumnType("char(1)");

            builder.Property(prop => prop.DataFabricacao)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("DataFabricacao")
                .HasColumnType("datetime");

            builder.Property(prop => prop.DataValidade)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("DataValidade")
                .HasColumnType("datetime");

            builder.Property(prop => prop.CodigoFornecedor)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("CodigoFornecedor")
                .HasColumnType("int");


            builder.HasOne(p => p.Fornecedor)
            .WithMany()
            .HasForeignKey(p => p.CodigoFornecedor);
        }
    }
}
