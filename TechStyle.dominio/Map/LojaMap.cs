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
    class LojaMap : IEntityTypeConfiguration<Loja>
    {
        public void Configure(EntityTypeBuilder<Loja> builder)
        {
            builder.ToTable("tbl_loja");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdProduto)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Quantidade)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.QuantidadeMinima)
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne<Produto>(x => x.Produto)
                .WithOne(y => y.Loja)
                .HasForeignKey<Loja>(i => i.IdProduto);
        }
    }
}
