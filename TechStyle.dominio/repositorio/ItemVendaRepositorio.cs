using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.dominio.Modelo;

namespace TechStyle.dominio.repositorio
{
    public class ItemVendaRepositorio : BaseRepositorio<ItemVenda>
    {
        public List<ItemVenda> BuscarPorVendaId(int idVenda)
            => Contexto.ItemVenda.Where(x => x.IdVenda == idVenda).ToList();

        public IQueryable<ItemVenda> BuscarPorProdutoId(int idProduto)
            => Contexto.ItemVenda.Where(x => x.IdProduto == idProduto);

        public override bool Incluir(ItemVenda entity)
        {

            return base.Incluir(entity);
        }
    }
}
