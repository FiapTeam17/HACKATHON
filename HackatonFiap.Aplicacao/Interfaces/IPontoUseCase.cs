using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackatonFiap.Dominio.Ponto.Dtos;

namespace HackatonFiap.Aplicacao.Interfaces
{
    public interface IPontoUseCase
    {
        Task RegistrarPonto(RegistroPontoDto registroPontoDto);
        Task<List<RegistroPontoDtoRetorno>> listarRegistrosFuncionario(string emailFuncionario);
        Task<SolicitacaoRegistrosRetornoDto> ObterRegistrosDePontoDia(SolicitacaoRegistrosDiaDto solicitacaoRegistrosDiaDto);
    }
}
