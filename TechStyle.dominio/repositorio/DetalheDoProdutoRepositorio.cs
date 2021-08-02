using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.dominio.Modelo;

namespace TechStyle.dominio.repositorio
{
    public class DetalheDoProdutoRepositorio : BaseRepositorio<DetalheDoProduto>
    {
        public bool Incluir(int idProduto, DetalheDoProduto detalhe)
        {

            detalhe.SetarIdProduto(idProduto);
            if (Existe(detalhe)) return false;

            return base.Incluir(detalhe);

        }
        public bool Alterar(int idProduto, DetalheDoProduto alterado)
        {
            var paraAlterar = BuscarPorProdutoId(idProduto);
            paraAlterar.Alterar(alterado);

            if (Existe(paraAlterar)) return false;

            return base.Alterar(paraAlterar);
        }

        public DetalheDoProduto BuscarPorProdutoId(int idProduto)
        {
            return Contexto.DetalheDoProduto.SingleOrDefault(x => x.IdProduto == idProduto);
        }

        public override bool Existe(DetalheDoProduto entity)
            => Contexto.DetalheDoProduto.Any(x => x.Marca == entity.Marca
                                            && x.Tamanho == entity.Tamanho
                                            && x.Cor == entity.Cor
                                            && x.Modelo == entity.Modelo);
    }
}
