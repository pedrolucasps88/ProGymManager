﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProGymManager.Dados;

#nullable disable

namespace ProGymManager.Dados.Migrations
{
    [DbContext(typeof(ProGymManagerContext))]
    [Migration("20250222204332_AtualizarTreinoExercicio")]
    partial class AtualizarTreinoExercicio
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProGymManager.Modelos.Alunos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("ativo")
                        .HasColumnType("bit");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("numeroMatricula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("personalId")
                        .HasColumnType("int");

                    b.Property<byte>("plano")
                        .HasColumnType("tinyint");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("personalId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("ProGymManager.Modelos.Exercicios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Musculo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Exercicios");
                });

            modelBuilder.Entity("ProGymManager.Modelos.Funcionarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("numeroMatricula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("ProGymManager.Modelos.Modelos.TreinoExercicio", b =>
                {
                    b.Property<int>("TreinoId")
                        .HasColumnType("int");

                    b.Property<int>("ExercicioId")
                        .HasColumnType("int");

                    b.HasKey("TreinoId", "ExercicioId");

                    b.HasIndex("ExercicioId");

                    b.ToTable("TreinoExercicio");
                });

            modelBuilder.Entity("ProGymManager.Modelos.Personais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("numeroMatricula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personais");
                });

            modelBuilder.Entity("ProGymManager.Modelos.Solicitacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AlunoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PersonalId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TreinoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("PersonalId");

                    b.HasIndex("TreinoId");

                    b.ToTable("Solicitacao");
                });

            modelBuilder.Entity("ProGymManager.Modelos.Treino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AlunoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.ToTable("Treinos");
                });

            modelBuilder.Entity("ProGymManager.Modelos.Alunos", b =>
                {
                    b.HasOne("ProGymManager.Modelos.Personais", "personal")
                        .WithMany("Alunos")
                        .HasForeignKey("personalId");

                    b.Navigation("personal");
                });

            modelBuilder.Entity("ProGymManager.Modelos.Modelos.TreinoExercicio", b =>
                {
                    b.HasOne("ProGymManager.Modelos.Exercicios", "Exercicio")
                        .WithMany("TreinoExercicios")
                        .HasForeignKey("ExercicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProGymManager.Modelos.Treino", "Treino")
                        .WithMany("TreinoExercicios")
                        .HasForeignKey("TreinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercicio");

                    b.Navigation("Treino");
                });

            modelBuilder.Entity("ProGymManager.Modelos.Solicitacao", b =>
                {
                    b.HasOne("ProGymManager.Modelos.Alunos", "aluno")
                        .WithMany("solicitacoes")
                        .HasForeignKey("AlunoId");

                    b.HasOne("ProGymManager.Modelos.Personais", "personal")
                        .WithMany("solicitacaos")
                        .HasForeignKey("PersonalId");

                    b.HasOne("ProGymManager.Modelos.Treino", "treino")
                        .WithMany()
                        .HasForeignKey("TreinoId");

                    b.Navigation("aluno");

                    b.Navigation("personal");

                    b.Navigation("treino");
                });

            modelBuilder.Entity("ProGymManager.Modelos.Treino", b =>
                {
                    b.HasOne("ProGymManager.Modelos.Alunos", "Aluno")
                        .WithMany("treinos")
                        .HasForeignKey("AlunoId");

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("ProGymManager.Modelos.Alunos", b =>
                {
                    b.Navigation("solicitacoes");

                    b.Navigation("treinos");
                });

            modelBuilder.Entity("ProGymManager.Modelos.Exercicios", b =>
                {
                    b.Navigation("TreinoExercicios");
                });

            modelBuilder.Entity("ProGymManager.Modelos.Personais", b =>
                {
                    b.Navigation("Alunos");

                    b.Navigation("solicitacaos");
                });

            modelBuilder.Entity("ProGymManager.Modelos.Treino", b =>
                {
                    b.Navigation("TreinoExercicios");
                });
#pragma warning restore 612, 618
        }
    }
}
