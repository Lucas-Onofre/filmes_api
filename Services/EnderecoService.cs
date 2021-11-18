using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Endereco;
using FilmesApi.Models;
using FluentResults;

namespace FilmesApi.Services
{
    public class EnderecoService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

    public ReadEnderecoDto AdicionaEndereco(CreateEnderecoDto enderecoDto)
    {
        Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
        _context.Enderecos.Add(endereco);
        _context.SaveChanges();
        return _mapper.Map<ReadEnderecoDto>(endereco);
    }

    public List<Endereco> RecuperaEnderecos()
    {
        List<Endereco> enderecos = _context.Enderecos.ToList();
        if(enderecos == null){
            return null;
        }
        return _mapper.Map<List<Endereco>>(enderecos);
    }

    public ReadEnderecoDto RecuperaEnderecosPorId(int id)
    {
        Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco != null)
        {
        ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
        return enderecoDto;
        }
        return null;
    }

    public Result AtualizaFilme(int id, UpdateEnderecoDto enderecoDto)
    {
        Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null)
        {
            return Result.Fail("Endereço não encontrado");
        }
        _mapper.Map(enderecoDto, endereco);
        _context.SaveChanges();
        return Result.Ok();
    }

    internal Result DeletaEndereco(int id)
    {
        Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null)
        {
            return Result.Fail("Endereço não encontrado");
        }
        _context.Remove(endereco);
        _context.SaveChanges();
        return Result.Ok();
    }
  }
}