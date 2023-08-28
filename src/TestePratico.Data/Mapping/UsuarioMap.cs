using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TestePratico.Domain.Entities;

namespace TestePratico.Infra.Data.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Nome)
                    .IsRequired()
                    .HasColumnName("Nome")
                    .HasColumnType("varchar(64)");

            builder.Property(prop => prop.CPF)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasColumnType("varchar(11)");

            builder.Property(prop => prop.Profissao)
                    .IsRequired()
                    .HasColumnName("Profissao")
                    .HasColumnType("varchar(14)");

            builder.Property(prop => prop.DataNascimento)
                    .IsRequired()
                    .HasColumnName("DataNascimento")
                    .HasColumnType("DATE");

            builder.Property(prop => prop.Email)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType("varchar(64)");

            builder.Property(prop => prop.Login)
                .IsRequired()
                .HasColumnName("Login")
                .HasColumnType("varchar(64)");

            builder.Property(prop => prop.Senha)
                .IsRequired()
                .HasColumnName("Senha")
                .HasColumnType("varchar(256)");

            builder.Property(prop => prop.Tipo)
                .IsRequired()
                .HasColumnName("Tipo")
                .HasColumnType("tinyint");

            builder.Property(prop => prop.Ativo)
                .IsRequired()
                .HasColumnName("Ativo")
                .HasColumnType("bit");

            builder.HasMany(pai => pai.Candidaturas)
                .WithOne(filho => filho.Usuario)
                .HasForeignKey(filho => filho.FkIdUsuario);
        }
    }
}