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
    public class EstoqueMap : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.ToTable("tbl_estoque");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Local)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.QuantidadeAtual)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.QuantidadeMinima)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.QuantidadeTotal)
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne<Produto>(x => x.Produto)
                .WithOne(x => x.Estoque)
                .HasForeignKey<Estoque>(i => i.IdProduto);
        }
    }
}
