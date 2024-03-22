using HackatonFiap.Dominio.Ponto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonFiap.Infraestrutura.Configurations;
internal class SolicitaRelatorioConfiguration : IEntityTypeConfiguration<SolicitaRelatorioPontoModel>
{
    public void Configure(EntityTypeBuilder<SolicitaRelatorioPontoModel> builder)
    {
        builder.ToTable("solicitaPonto");
        builder.HasKey(c => c.Id);
        builder
            .HasOne(a => a.Funcionario)
            .WithMany(a => a.SolicitaRelatorioPontos)
            .HasConstraintName("FK_SolicitaPonto_Funcionario");
    }
}