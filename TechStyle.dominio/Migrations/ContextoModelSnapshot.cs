﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechStyle.dominio;

namespace TechStyle.dominio.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TechStyle.dominio.Modelo.DetalheDoProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Tamanho")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdProduto")
                        .IsUnique();

                    b.ToTable("tbl_detalhe_produto");
                });

            modelBuilder.Entity("TechStyle.dominio.Modelo.Estoque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("QuantidadeAtual")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeMinima")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeTotal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdProduto")
                        .IsUnique();

                    b.ToTable("tbl_estoque");
                });

            modelBuilder.Entity("TechStyle.dominio.Modelo.ItemVenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<int>("IdVenda")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdProduto");

                    b.HasIndex("IdVenda");

                    b.ToTable("tbl_item_venda");
                });

            modelBuilder.Entity("TechStyle.dominio.Modelo.Loja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeMinima")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdProduto")
                        .IsUnique();

                    b.ToTable("tbl_loja");
                });

            modelBuilder.Entity("TechStyle.dominio.Modelo.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("IdSegmento")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("ValorDeVenda")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdSegmento");

                    b.ToTable("tbl_produto");
                });

            modelBuilder.Entity("TechStyle.dominio.Modelo.Segmento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Subcategoria")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("tbl_segmento");
                });

            modelBuilder.Entity("TechStyle.dominio.Modelo.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Desconto")
                        .HasColumnType("decimal(8,2)");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("Id");

                    b.ToTable("tbl_venda");
                });

            modelBuilder.Entity("TechStyle.dominio.Modelo.DetalheDoProduto", b =>
                {
                    b.HasOne("TechStyle.dominio.Modelo.Produto", "Produto")
                        .WithOne("DetalheDoProduto")
                        .HasForeignKey("TechStyle.dominio.Modelo.DetalheDoProduto", "IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("TechStyle.dominio.Modelo.Estoque", b =>
                {
                    b.HasOne("TechStyle.dominio.Modelo.Produto", "Produto")
                        .WithOne("Estoque")
                        .HasForeignKey("TechStyle.dominio.Modelo.Estoque", "IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("TechStyle.dominio.Modelo.ItemVenda", b =>
                {
                    b.HasOne("TechStyle.dominio.Modelo.Produto", "Produto")
                        .WithMany("ItensVenda")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechStyle.dominio.Modelo.Venda", "Venda")
                        .WithMany("ItensVenda")
                        .HasForeignKey("IdVenda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("TechStyle.dominio.Modelo.Loja", b =>
                {
                    b.HasOne("TechStyle.dominio.Modelo.Produto", "Produto")
                        .WithOne("Loja")
                        .HasForeignKey("TechStyle.dominio.Modelo.Loja", "IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("TechStyle.dominio.Modelo.Produto", b =>
                {
                    b.HasOne("TechStyle.dominio.Modelo.Segmento", "Segmento")
                        .WithMany("Produtos")
                        .HasForeignKey("IdSegmento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Segmento");
                });

            modelBuilder.Entity("TechStyle.dominio.Modelo.Produto", b =>
                {
                    b.Navigation("DetalheDoProduto");

                    b.Navigation("Estoque");

                    b.Navigation("ItensVenda");

                    b.Navigation("Loja");
                });

            modelBuilder.Entity("TechStyle.dominio.Modelo.Segmento", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("TechStyle.dominio.Modelo.Venda", b =>
                {
                    b.Navigation("ItensVenda");
                });
#pragma warning restore 612, 618
        }
    }
}
