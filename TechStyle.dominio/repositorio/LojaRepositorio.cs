using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.dominio.Modelo;

namespace TechStyle.dominio.repositorio
{
    public class LojaRepositorio : BaseRepositorio<Loja>
    {
        public Loja BuscarPorProdutoId(int idProduto) 
            => Contexto.Loja.FirstOrDefault(x => x.IdProduto == idProduto);


        public bool Alterar(int idProduto, Loja lojaAlterada)
        {
            var lojaParaAlterar = BuscarPorProdutoId(idProduto);

            lojaParaAlterar.Alterar(lojaAlterada);

            return base.Alterar(lojaParaAlterar);

        }
    }
}
