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
    [Route("api/vendas")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly VendaRepositorio _repo;

        public VendaController(VendaRepositorio repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Venda> Get()
        {
            return _repo.BuscarTudo();
        }

        // GET api/<VendaController>/5
        [HttpGet("{id}")]
        public Venda Get(int id)
        {
            return _repo.BuscarPorId(id);
        }

        // POST api/<VendaController>
        [HttpPost]
        public void Post([FromBody] VendaDto dto)
        {
            _repo.Incluir(new Venda().Cadastrar(dto.ValorTotal, dto.Desconto));
        }

        // PUT api/<VendaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] VendaDto dto)
        {
            _repo.Alterar(id, new Venda().Cadastrar(dto.ValorTotal, dto.Desconto));
        }

        // DELETE api/<VendaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
