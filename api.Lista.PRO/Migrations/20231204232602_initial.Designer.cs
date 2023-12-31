﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Lista.PRO.Context;

#nullable disable

namespace api.Lista.PRO.Migrations
{
    [DbContext(typeof(ContextData))]
    [Migration("20231204232602_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("api.Lista.PRO.Models.Condominio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Condominios");
                });

            modelBuilder.Entity("api.Lista.PRO.Models.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnderecoId"));

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CondominioId")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EnderecoId");

                    b.HasIndex("CondominioId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("api.Lista.PRO.Models.Equipamento", b =>
                {
                    b.Property<int>("EquipamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EquipamentoId"));

                    b.Property<int>("CondominioId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroDeSerie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EquipamentoId");

                    b.HasIndex("CondominioId");

                    b.ToTable("Equipamentos");
                });

            modelBuilder.Entity("api.Lista.PRO.Models.Preventiva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CondominioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataExecucao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CondominioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Preventivas");
                });

            modelBuilder.Entity("api.Lista.PRO.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("api.Lista.PRO.Models.Endereco", b =>
                {
                    b.HasOne("api.Lista.PRO.Models.Condominio", "Condominio")
                        .WithOne("Endereco")
                        .HasForeignKey("api.Lista.PRO.Models.Endereco", "CondominioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Condominio");
                });

            modelBuilder.Entity("api.Lista.PRO.Models.Equipamento", b =>
                {
                    b.HasOne("api.Lista.PRO.Models.Condominio", "Condominio")
                        .WithMany("Equipamentos")
                        .HasForeignKey("CondominioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Condominio");
                });

            modelBuilder.Entity("api.Lista.PRO.Models.Preventiva", b =>
                {
                    b.HasOne("api.Lista.PRO.Models.Condominio", null)
                        .WithMany("ManutencoesPreventivas")
                        .HasForeignKey("CondominioId");

                    b.HasOne("api.Lista.PRO.Models.Usuario", "Usuario")
                        .WithMany("Preventivas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("api.Lista.PRO.Models.Condominio", b =>
                {
                    b.Navigation("Endereco")
                        .IsRequired();

                    b.Navigation("Equipamentos");

                    b.Navigation("ManutencoesPreventivas");
                });

            modelBuilder.Entity("api.Lista.PRO.Models.Usuario", b =>
                {
                    b.Navigation("Preventivas");
                });
#pragma warning restore 612, 618
        }
    }
}
