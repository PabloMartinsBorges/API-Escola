using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Infra.Data.EntitiesConfiguration
{
    // Configuração da entidade Curso
    // This class implements the IEntityTypeConfiguration interface to configure the Curso entity.
    // It defines the primary key, required properties, and their maximum lengths.
    // The configuration is applied when the model is being built in the DbContext.
    // The Configure method is called by the Entity Framework Core when building the model.
    public class CursoConfiguration : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.Descricao)
                .HasMaxLength(150);
    
        }
    }
}
