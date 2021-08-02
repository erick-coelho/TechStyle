using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStyle.API.DTO;
using TechStyle.dominio.Modelo;
using TechStyle.dominio.repositorio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechStyle.API.Controllers
{
    [Route("api/produtos/{idProduto}")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly EstoqueRepositorio _repo;

        public EstoqueController(EstoqueRepositorio repo)
        {
            _repo = repo;
        }

        // GET: api/<EstoqueController>
        [HttpGet("estoque")]
        public Estoque Get(int idProduto)
        {
            return _repo.BuscarPorProdutoId(idProduto);
        }

        // POST api/<EstoqueController>
        [HttpPost("estoque")]
        public void Post([FromBody] EstoqueDto dto, int idProduto)
        {
            _repo.Incluir(new Estoque().Cadastrar(idProduto, dto.QuantidadeTotal, dto.QuantidadeMinima,
                                                  dto.QuantidadeAtual, dto.Local));
        }

        // PUT api/<EstoqueController>/5
        [HttpPut("estoque")]
        public void Put(int idProduto, [FromBody] EstoqueDto dto)
        {
            _repo.Alterar(idProduto, new Estoque().Cadastrar(idProduto, dto.QuantidadeTotal, dto.QuantidadeMinima, dto.QuantidadeAtual, dto.Local));
        }
    }
}
