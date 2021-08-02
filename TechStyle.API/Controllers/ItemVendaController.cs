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
    [Route("api/vendas/{idVenda}")]
    [ApiController]
    public class ItemVendaController : ControllerBase
    {
        private readonly ItemVendaRepositorio _repo;
        public ItemVendaController(ItemVendaRepositorio ivRepo)
        {
            _repo = ivRepo;
        }
        [HttpGet("itens")]
        public IEnumerable<ItemVenda> Get(int idVenda)
        {
            return _repo.BuscarPorVendaId(idVenda);
        }


        // POST api/<ItemVendaController>
        [HttpPost("itens")]
        public void Post([FromBody] ItemVendaDto dto, int idVenda, [FromQuery] int idProduto)
        {
            _repo.Incluir(new ItemVenda().Cadastrar(idVenda, idProduto, dto.Quantidade));
        }

        // PUT api/<ItemVendaController>/5
        [HttpPut("itens/{id}")]
        public void Put(int idVenda, int id, [FromBody] ItemVendaDto dto)
        {

        }
    }
}
