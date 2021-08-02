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
    class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("tbl_produto");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.SKU)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.ValorDeVenda)
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne<Segmento>(x => x.Segmento)
                .WithMany(y => y.Produtos)
                .HasForeignKey(i => i.IdSegmento);
        }
    }
}
