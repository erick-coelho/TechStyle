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
    class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("tbl_venda");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Data)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(x => x.Desconto)
                .HasColumnType("decimal(8,2)")
                .IsRequired();

            builder.Property(x => x.ValorTotal)
                .HasColumnType("decimal(8,2)")
                .IsRequired();
        }
    }
}
