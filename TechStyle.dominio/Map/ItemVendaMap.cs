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
    class ItemVendaMap : IEntityTypeConfiguration<ItemVenda>
    {
        public void Configure(EntityTypeBuilder<ItemVenda> builder)
        {
            builder.ToTable("tbl_item_venda");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdProduto)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.IdVenda)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Quantidade)
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne<Produto>(x => x.Produto)
                .WithMany(y => y.ItensVenda)
                .HasForeignKey(i => i.IdProduto);

            builder.HasOne<Venda>(x => x.Venda)
                .WithMany(y => y.ItensVenda)
                .HasForeignKey(i => i.IdVenda);
                
        }
    }
}
