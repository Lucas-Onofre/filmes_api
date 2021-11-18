using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Endereco;
using FilmesApi.Models;
using FilmesApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            ReadEnderecoDto readDto = _enderecoService.AdicionaEndereco(enderecoDto);
            
            return CreatedAtAction(nameof(RecuperaEnderecosPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaEnderecos()
        {
            List<Endereco> readDto = _enderecoService.RecuperaEnderecos();
            if(readDto == null){
                return NotFound();
            }
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecosPorId(int id)
        {
            ReadEnderecoDto readDto = _enderecoService.RecuperaEnderecosPorId(id);
            
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Result resultado = _enderecoService.AtualizaFilme(id, enderecoDto);
            if(resultado.IsFailed){
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            Result resultado = _enderecoService.DeletaEndereco(id);
            if(resultado.IsFailed){
                return NotFound();
            }
            return NoContent();
        }
    }
}