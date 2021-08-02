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
    [Route("api/produtos/{idProduto}")]
    [ApiController]
    public class DetalheDoProdutoController : ControllerBase
    {
        private readonly DetalheDoProdutoRepositorio _repo;
        private readonly ProdutoRepositorio _prodRepo;

        public DetalheDoProdutoController(DetalheDoProdutoRepositorio repo, ProdutoRepositorio prodRepo)
        {
            _repo = repo;
            _prodRepo = prodRepo;
        }


        [HttpGet("detalhe")]
        public DetalheDoProduto Get(int idProduto)
        {
            return _repo.BuscarPorProdutoId(idProduto);
        }

        [HttpPost("detalhe")]
        public void Post([FromBody] DetalheDoProdutoDto dto, int idProduto)
        { 
            _repo.Incluir(new DetalheDoProduto().Cadastrar(dto.Marca, dto.Tamanho, dto.Cor, dto.Modelo, idProduto));
        }

        [HttpPut("detalhe")]
        public void Put(int idProduto, [FromBody] DetalheDoProdutoDto dto)
        {

            _repo.Alterar(idProduto, new DetalheDoProduto()
                                    .Cadastrar(dto.Marca, dto.Tamanho, dto.Cor, dto.Modelo, idProduto));
        }

    }
}
