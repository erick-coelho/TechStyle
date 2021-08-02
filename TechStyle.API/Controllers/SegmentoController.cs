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
    [Route("api/segmentos")]
    [ApiController]
    public class SegmentoController : ControllerBase
    {
        private readonly SegmentoRepositorio _repo;

        public SegmentoController(SegmentoRepositorio repo)
        {
            _repo = repo;
        }
        
        [HttpGet]
        public IEnumerable<Segmento> Get()
        {
            return _repo.BuscarTudo();

        }

        [HttpGet("{id}")]
        public Segmento Get(int id)
        {
            return _repo.BuscarPorId(id);
        }

        [HttpPost]
        public void Post([FromBody] SegmentoDto dto)
        {
            _repo.Incluir(new Segmento().Cadastrar(dto.Categoria, dto.SubCategoria));
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] SegmentoDto dto)
        {
            _repo.Alterar(id, new Segmento().Cadastrar(dto.Categoria, dto.SubCategoria));
        }

    }
}
