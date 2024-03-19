using HackatonFiap.Dominio.Funcionario.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HackatonFiap.Infraestrutura.Configurations
{
    public class FuncionarioConfiguration : IEntityTypeConfiguration<FuncionarioModel>
    {
        public void Configure(EntityTypeBuilder<FuncionarioModel> builder)
        {
            builder.ToTable("funcionario");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome).HasMaxLength(200).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(200).IsRequired();
        }
    }
}
