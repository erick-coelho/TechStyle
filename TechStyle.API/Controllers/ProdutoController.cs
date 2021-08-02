using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStyle.API.DTO;
using TechStyle.dominio.Modelo;
using TechStyle.dominio.repositorio;


namespace TechStyle.API.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private readonly ProdutoRepositorio _repo;

        public ProdutoController(ProdutoRepositorio repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            return _repo.BuscarTudo();
        }

        [HttpGet("{id}")]
        public Produto Get(int id)
        {
            return _repo.BuscarPorId(id);
        }

        [HttpPost]
        public void Post([FromBody] ProdutoDto dto)
        {
            _repo.Incluir(new Produto().Cadastrar(dto.ValorDeVenda, dto.Nome, dto.SKU, dto.IdSegmento));
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProdutoDto dto)
        {
            _repo.Alterar(id, new Produto().Cadastrar(dto.ValorDeVenda, dto.Nome, dto.SKU, dto.IdSegmento));
        }
        
    }
}
