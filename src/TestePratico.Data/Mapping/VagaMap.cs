using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TestePratico.Domain.Entities;

namespace TestePratico.Infra.Data.Mapping
{
    public class VagaMap : IEntityTypeConfiguration<Vaga>
    {
        public void Configure(EntityTypeBuilder<Vaga> builder)
        {
            builder.ToTable("Vaga");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Titulo)
                    .IsRequired()
                    .HasColumnName("Titulo")
                    .HasColumnType("varchar(64)");

            builder.Property(prop => prop.Descricao)
                    .IsRequired()
                    .HasColumnName("Descricao")
                    .HasColumnType("varchar(245)");

            builder.Property(prop => prop.Salario)
                    .IsRequired()
                    .HasColumnName("Salario")
                    .HasColumnType("Decimal(8,2)");

           
            builder.HasMany(pai => pai.Candidaturas)
                .WithOne(filho => filho.Vaga)
                .HasForeignKey(filho => filho.FkIdVaga);
        }
    }
}