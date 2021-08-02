using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStyle.API.DTO
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public decimal ValorDeVenda { get; set; }
        public string Nome { get; set; }
        public string SKU { get; set; }
        public int IdSegmento { get; set; }
    }
}
