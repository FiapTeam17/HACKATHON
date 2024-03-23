using HackatonFiap.Dominio.Ponto.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonFiap.Aplicacao.Interfaces;
public interface ISolicitaRelatorioPontoUseCase
{
    Task SolicitaRelatorioPonto(SolicitaRelatorioPontoDto solicitaRelatorioPontoDto);
}
