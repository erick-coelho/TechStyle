using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStyle.API.DTO
{
    public class EstoqueDto
    {
        public int Id { get; set; }
        public int QuantidadeTotal { get; set; }
        public int QuantidadeMinima { get; set; }
        public int QuantidadeAtual { get; set; }
        public string Local { get; set; }
    }
}
