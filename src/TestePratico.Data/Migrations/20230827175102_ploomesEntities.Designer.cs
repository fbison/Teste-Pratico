﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestePratico.Infra.Data.Context;

namespace TestePratico.Infra.Data.Migrations
{
    [DbContext(typeof(DataDbContext))]
    [Migration("20230827175102_ploomesEntities")]
    partial class ploomesEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestePratico.Domain.Entities.Candidatura", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FkIdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FkIdVaga")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FkIdUsuario");

                    b.HasIndex("FkIdVaga");

                    b.ToTable("Candidatura");
                });

            modelBuilder.Entity("TestePratico.Domain.Entities.Empresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("varchar(14)")
                        .HasColumnName("Cnpj");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(64)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("TestePratico.Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("Ativo");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("CPF");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("DATE")
                        .HasColumnName("DataNascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(64)")
                        .HasColumnName("Email");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(64)")
                        .HasColumnName("Login");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(64)")
                        .HasColumnName("Nome");

                    b.Property<string>("Profissao")
                        .IsRequired()
                        .HasColumnType("varchar(14)")
                        .HasColumnName("Profissao");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasColumnName("Senha");

                    b.Property<byte>("Tipo")
                        .HasColumnType("tinyint")
                        .HasColumnName("Tipo");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("TestePratico.Domain.Entities.Vaga", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(245)")
                        .HasColumnName("Descricao");

                    b.Property<Guid>("FkIdEmpresa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Salario")
                        .HasColumnType("Decimal(8,2)")
                        .HasColumnName("Salario");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(64)")
                        .HasColumnName("Titulo");

                    b.HasKey("Id");

                    b.HasIndex("FkIdEmpresa");

                    b.ToTable("Vaga");
                });

            modelBuilder.Entity("TestePratico.Domain.Entities.Candidatura", b =>
                {
                    b.HasOne("TestePratico.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Candidaturas")
                        .HasForeignKey("FkIdUsuario")
                        .IsRequired();

                    b.HasOne("TestePratico.Domain.Entities.Vaga", "Vaga")
                        .WithMany("Candidaturas")
                        .HasForeignKey("FkIdVaga")
                        .IsRequired();

                    b.Navigation("Usuario");

                    b.Navigation("Vaga");
                });

            modelBuilder.Entity("TestePratico.Domain.Entities.Vaga", b =>
                {
                    b.HasOne("TestePratico.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Vagas")
                        .HasForeignKey("FkIdEmpresa")
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("TestePratico.Domain.Entities.Empresa", b =>
                {
                    b.Navigation("Vagas");
                });

            modelBuilder.Entity("TestePratico.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Candidaturas");
                });

            modelBuilder.Entity("TestePratico.Domain.Entities.Vaga", b =>
                {
                    b.Navigation("Candidaturas");
                });
#pragma warning restore 612, 618
        }
    }
}
