using AutoMapper;
using HackatonFiap.Comum;
using HackatonFiap.Dominio.Funcionario.Dtos;
using HackatonFiap.Dominio.Funcionario.Entities;
using HackatonFiap.Dominio.Funcionario.Models;

namespace HackatonFiap.Dominio.Funcionario.AutoMapper;

public class FuncionarioAutomapper : Profile
{
    public FuncionarioAutomapper()
    {
        CreateMap<FuncionarioEntity, FuncionarioModel>().ReverseMap();
        CreateMap<FuncionarioDto, FuncionarioEntity>()
            .ForMember(fe => fe.Id, opt => opt.Ignore());
        CreateMap<FuncionarioModel, FuncionarioDtoRetorno>();
        CreateMap<ListaPaginada<FuncionarioModel>, ListaPaginada<FuncionarioDtoRetorno>>();
    }
}