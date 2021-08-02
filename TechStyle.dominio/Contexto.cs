using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.dominio.Map;
using TechStyle.dominio.Modelo;

namespace TechStyle.dominio
{
    public class Contexto : DbContext
    {
        public DbSet<DetalheDoProduto> DetalheDoProduto { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<ItemVenda> ItemVenda { get; set; }
        public DbSet<Loja> Loja { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Segmento> Segmento { get; set; }
        public DbSet<Venda> Venda { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-KH268NN; Database=TechStyle; Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DetalheDoProdutoMap());
            modelBuilder.ApplyConfiguration(new EstoqueMap());
            modelBuilder.ApplyConfiguration(new ItemVendaMap());
            modelBuilder.ApplyConfiguration(new LojaMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new SegmentoMap());
            modelBuilder.ApplyConfiguration(new VendaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
