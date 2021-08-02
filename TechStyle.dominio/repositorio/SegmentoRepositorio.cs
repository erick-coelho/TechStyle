using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.dominio.Modelo;
using Microsoft.EntityFrameworkCore;

namespace TechStyle.dominio.repositorio
{
    public class SegmentoRepositorio : BaseRepositorio<Segmento>
    {
        public bool Alterar(int id, Segmento segmento)
        {
            Segmento segmentoParaAlterar = base.BuscarPorId(id);

            if (Existe(segmento)) return false;

            segmentoParaAlterar.Alterar(segmento);
            return base.Alterar(segmentoParaAlterar);
        }


        public override bool Existe(Segmento entity) => Contexto.Segmento.Any(x => x.Categoria == entity.Categoria && x.Subcategoria == entity.Subcategoria);
    }
}
