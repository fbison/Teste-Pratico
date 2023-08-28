using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TestePratico.Domain.Entities;

namespace TestePratico.Infra.Data.Mapping
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Nome)
                    .IsRequired()
                    .HasColumnName("Nome")
                    .HasColumnType("varchar(64)");

            builder.Property(prop => prop.Cnpj)
                    .IsRequired()
                    .HasColumnName("Cnpj")
                    .HasColumnType("varchar(14)");

            builder.HasMany(pai => pai.Vagas)
                .WithOne(filho => filho.Empresa)
                .HasForeignKey(filho => filho.FkIdEmpresa);
        }
    }
}