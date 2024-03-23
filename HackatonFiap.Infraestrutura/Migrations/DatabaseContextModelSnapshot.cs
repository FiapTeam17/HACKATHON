﻿// <auto-generated />
using System;
using HackatonFiap.Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HackatonFiap.Infraestrutura.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HackatonFiap.Dominio.Funcionario.Models.FuncionarioModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CognitoId")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("funcionario", (string)null);
                });

            modelBuilder.Entity("HackatonFiap.Dominio.Ponto.Models.PontoModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("FuncionarioId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Horario")
                        .HasMaxLength(200)
                        .HasColumnType("datetime(6)");

                    b.Property<int>("tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("ponto", (string)null);
                });

            modelBuilder.Entity("HackatonFiap.Dominio.Ponto.Models.SolicitaRelatorioPontoModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CaminhoArquivo")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("FuncionarioId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("solicitaPonto", (string)null);
                });

            modelBuilder.Entity("HackatonFiap.Dominio.Ponto.Models.PontoModel", b =>
                {
                    b.HasOne("HackatonFiap.Dominio.Funcionario.Models.FuncionarioModel", "Funcionario")
                        .WithMany("Pontos")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Ponto_Funcionario");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("HackatonFiap.Dominio.Ponto.Models.SolicitaRelatorioPontoModel", b =>
                {
                    b.HasOne("HackatonFiap.Dominio.Funcionario.Models.FuncionarioModel", "Funcionario")
                        .WithMany("SolicitaRelatorioPontos")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_SolicitaPonto_Funcionario");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("HackatonFiap.Dominio.Funcionario.Models.FuncionarioModel", b =>
                {
                    b.Navigation("Pontos");

                    b.Navigation("SolicitaRelatorioPontos");
                });
#pragma warning restore 612, 618
        }
    }
}
