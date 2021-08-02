using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.dominio.Modelo;

namespace TechStyle.dominio.repositorio
{
    public class VendaRepositorio : BaseRepositorio<Venda>
    {
        public bool Alterar(int id, Venda vendaAlterada)
        {
            var vendaParaAlterar = BuscarPorId(id);
            vendaParaAlterar.Alterar(vendaAlterada);
            return base.Alterar(vendaParaAlterar);
        }
    }
}
