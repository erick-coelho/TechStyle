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
    class SegmentoMap : IEntityTypeConfiguration<Segmento>
    {
        public void Configure(EntityTypeBuilder<Segmento> builder)
        {
            builder.ToTable("tbl_segmento");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Categoria)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Subcategoria)
                .HasColumnType("varchar(100)")
                .IsRequired();
        }
    }
}
