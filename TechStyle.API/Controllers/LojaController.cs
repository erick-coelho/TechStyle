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
    public class LojaController : ControllerBase
    {
        private readonly LojaRepositorio _repo;
        public LojaController(LojaRepositorio repo)
        {
            _repo = repo;
        }
        [HttpGet("loja")]
        public Loja Get(int idProduto)
        {
            return _repo.BuscarPorProdutoId(idProduto);
        }

        [HttpPost("loja")]
        public void Post([FromBody] LojaDto dto, int idProduto)
        {
            _repo.Incluir(new Loja().Cadastrar(dto.Quantidade, dto.QuantidadeMinima, idProduto));
        }

        [HttpPut("loja")]
        public void Put(int idProduto, [FromBody] LojaDto dto)
        {
            _repo.Alterar(idProduto, new Loja().Cadastrar(dto.Quantidade, dto.QuantidadeMinima, idProduto));
        }
    }
}
