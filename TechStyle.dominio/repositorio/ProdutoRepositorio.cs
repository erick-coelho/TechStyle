using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.dominio.Modelo;

namespace TechStyle.dominio.repositorio
{
    public class ProdutoRepositorio : BaseRepositorio<Produto>
    {
        public void AlterarAtivo(int id, bool atv)
        {
            var produtoParaAlterar = base.BuscarPorId(id);
            produtoParaAlterar.AtualizarAtivo(atv);

            base.Alterar(produtoParaAlterar);
        }

        public List<Produto> BuscarPorSegmentoId(int idSegmento) => Contexto.Produto.Where(x => x.IdSegmento == idSegmento).ToList();

        public bool Alterar(int id, Produto produto)
        {
            Produto produtoParaAlterar = base.BuscarPorId(id);

            if (Existe(produto)) return false;

            produtoParaAlterar.Alterar(produto);
            return base.Alterar(produtoParaAlterar);
        }

        public override IQueryable<Produto> BuscarTudo()
        {
            return base.BuscarTudo()
                .Include(x => x.DetalheDoProduto)
                .Include(x => x.Segmento)
                .Include(x => x.Estoque)
                .Include(x => x.Loja);
        }
    }
}
