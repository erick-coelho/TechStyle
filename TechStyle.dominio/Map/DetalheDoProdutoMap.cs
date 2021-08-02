using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.dominio.Modelo;

namespace TechStyle.dominio.Map
{
    public class DetalheDoProdutoMap : IEntityTypeConfiguration<DetalheDoProduto>
    {
        public void Configure(EntityTypeBuilder<DetalheDoProduto> builder)
        {
            builder.ToTable("tbl_detalhe_produto");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Cor)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Marca)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Modelo)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Tamanho)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.IdProduto)
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne<Produto>(p => p.Produto)
                .WithOne(dp => dp.DetalheDoProduto)
                .HasForeignKey<DetalheDoProduto>(i => i.IdProduto);
        }
    }
}
