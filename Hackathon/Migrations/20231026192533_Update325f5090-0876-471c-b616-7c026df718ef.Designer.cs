﻿// <auto-generated />
using Hackathon.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hackathon.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231026192533_Update325f5090-0876-471c-b616-7c026df718ef")]
    partial class Update325f50900876471cb6167c026df718ef
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hackathon.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("Hackathon.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("Pessoa");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Pessoa");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Hackathon.Models.PessoaFisica", b =>
                {
                    b.HasBaseType("Hackathon.Models.Pessoa");

                    b.Property<long>("Cpf")
                        .HasColumnType("bigint");

                    b.HasDiscriminator().HasValue("PessoaFisica");
                });

            modelBuilder.Entity("Hackathon.Models.PessoaJuridica", b =>
                {
                    b.HasBaseType("Hackathon.Models.Pessoa");

                    b.Property<long>("Cnpj")
                        .HasColumnType("bigint");

                    b.HasDiscriminator().HasValue("PessoaJuridica");
                });

            modelBuilder.Entity("Hackathon.Models.Pessoa", b =>
                {
                    b.HasOne("Hackathon.Models.Endereco", "Endereco")
                        .WithOne()
                        .HasForeignKey("Hackathon.Models.Pessoa", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });
#pragma warning restore 612, 618
        }
    }
}
