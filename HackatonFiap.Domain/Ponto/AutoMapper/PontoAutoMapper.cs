using AutoMapper;
using HackatonFiap.Comum;
using HackatonFiap.Dominio.Funcionario.Dtos;
using HackatonFiap.Dominio.Funcionario.Entities;
using HackatonFiap.Dominio.Funcionario.Models;
using HackatonFiap.Dominio.Ponto.Dtos;
using HackatonFiap.Dominio.Ponto.Entities;
using HackatonFiap.Dominio.Ponto.Models;

namespace HackatonFiap.Dominio.Ponto.AutoMapper
{
    public class PontoAutoMapper : Profile
    {

        public PontoAutoMapper() {
            CreateMap<PontoEntity, PontoModel>().ReverseMap();
            //CreateMap<RegistroPontoDto, FuncionarioEntity>()
                //.ForMember(fe => fe.Id, opt => opt.Ignore());
            //CreateMap<PontoModel, FuncionarioDtoRetorno>();
            //CreateMap<ListaPaginada<FuncionarioModel>, ListaPaginada<FuncionarioDtoRetorno>>();
        }

    }
}
