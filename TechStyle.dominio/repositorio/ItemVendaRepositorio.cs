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
        private readonly LojaRepositorio _lojaRepo;
        private readonly VendaRepositorio _vendaRepo;
        private readonly ProdutoRepositorio _prodRepo;
        private readonly EstoqueRepositorio _estRepo;
        public ItemVendaRepositorio(LojaRepositorio lojaRepo, VendaRepositorio vendaRepo, ProdutoRepositorio prodRepo, EstoqueRepositorio estRepo) : base()
        {
            _lojaRepo = lojaRepo;
            _vendaRepo = vendaRepo;
            _prodRepo = prodRepo;
            _estRepo = estRepo;
        }

        public List<ItemVenda> BuscarPorVendaId(int idVenda)
            => Contexto.ItemVenda.Where(x => x.IdVenda == idVenda).ToList();

        public IQueryable<ItemVenda> BuscarPorProdutoId(int idProduto)
            => Contexto.ItemVenda.Where(x => x.IdProduto == idProduto);

        public override bool Incluir(ItemVenda entity)
        {
            var loja = _lojaRepo.BuscarPorProdutoId(entity.IdProduto);
            var estoque = _estRepo.BuscarPorProdutoId(entity.IdProduto);
            if (loja.RemoverQuantidade(entity.Quantidade))
            {
                estoque.AtualizarTotal(loja.Quantidade);
                
                _estRepo.Alterar(estoque);
                _lojaRepo.Alterar(loja);

                _vendaRepo.AdicionarTotal(_prodRepo.BuscarPorId(entity.IdProduto).ValorDeVenda * entity.Quantidade, entity.IdVenda);
                return base.Incluir(entity);
            }

            return false;
        }
    }
}
