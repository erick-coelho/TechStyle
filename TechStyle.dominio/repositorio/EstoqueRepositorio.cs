using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.dominio.Modelo;

namespace TechStyle.dominio.repositorio
{
    public class EstoqueRepositorio : BaseRepositorio<Estoque>
    {
        public Estoque BuscarPorProdutoId(int idProduto) 
            => Contexto.Estoque.FirstOrDefault(x => x.IdProduto == idProduto);

        public bool LocalOcupado(Estoque entity)
            => Contexto.Estoque.Any(x => x.Local == entity.Local);

        public bool Alterar(int idProduto, Estoque estoqueAlterado)
        {
            var EstoqueParaAlterar = BuscarPorProdutoId(idProduto);

            EstoqueParaAlterar.Alterar(estoqueAlterado);

            if (LocalOcupado(EstoqueParaAlterar)) return false;

            return base.Alterar(EstoqueParaAlterar);
        }
    }
}
