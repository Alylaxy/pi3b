﻿// <auto-generated />
using System;
using AcheASaida.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AcheASaida.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("AcheASaida.Entities.Grupo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("LabirintosConcluidos")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("MediaExploracao")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("MediaPassos")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("Pontuacao")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QtdLabirintosConcluidos")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Grupos");
                });

            modelBuilder.Entity("AcheASaida.Entities.InfoLabirinto", b =>
                {
                    b.Property<int>("IdLabirinto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Completo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Dificuldade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("GrupoId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Passos")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("PorcentagemExploracao")
                        .HasColumnType("TEXT");

                    b.HasKey("IdLabirinto");

                    b.HasIndex("GrupoId");

                    b.ToTable("InfoLabirintos");
                });

            modelBuilder.Entity("AcheASaida.Entities.Labirinto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Dificuldade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("EntradaId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EntradaId");

                    b.ToTable("Labirintos");
                });

            modelBuilder.Entity("AcheASaida.Entities.Vertice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Labirinto")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("LabirintoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tipo")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("VerticeId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LabirintoId");

                    b.HasIndex("VerticeId");

                    b.ToTable("Vertices");
                });

            modelBuilder.Entity("AcheASaida.Entities.InfoLabirinto", b =>
                {
                    b.HasOne("AcheASaida.Entities.Grupo", "Grupo")
                        .WithMany("Informacoes")
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grupo");
                });

            modelBuilder.Entity("AcheASaida.Entities.Labirinto", b =>
                {
                    b.HasOne("AcheASaida.Entities.Vertice", "Entrada")
                        .WithMany()
                        .HasForeignKey("EntradaId");

                    b.Navigation("Entrada");
                });

            modelBuilder.Entity("AcheASaida.Entities.Vertice", b =>
                {
                    b.HasOne("AcheASaida.Entities.Labirinto", null)
                        .WithMany("Vertices")
                        .HasForeignKey("LabirintoId");

                    b.HasOne("AcheASaida.Entities.Vertice", null)
                        .WithMany("Conexoes")
                        .HasForeignKey("VerticeId");
                });

            modelBuilder.Entity("AcheASaida.Entities.Grupo", b =>
                {
                    b.Navigation("Informacoes");
                });

            modelBuilder.Entity("AcheASaida.Entities.Labirinto", b =>
                {
                    b.Navigation("Vertices");
                });

            modelBuilder.Entity("AcheASaida.Entities.Vertice", b =>
                {
                    b.Navigation("Conexoes");
                });
#pragma warning restore 612, 618
        }
    }
}
