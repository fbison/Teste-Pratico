using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TestePratico.Domain.Entities;

namespace TestePratico.Infra.Data.Mapping
{
    public class CandidaturaMap : IEntityTypeConfiguration<Candidatura>
    {
        public void Configure(EntityTypeBuilder<Candidatura> builder)
        {
            builder.ToTable("Candidatura");

            builder.HasKey(prop => prop.Id);

        }
    }
}