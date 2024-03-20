using AutoMapper;
using HackatonFiap.Aplicacao.Interfaces;
using HackatonFiap.Comum;
using HackatonFiap.Comum.Notificacoes;
using HackatonFiap.Dominio.Funcionario.Dtos;
using HackatonFiap.Dominio.Funcionario.Entities;
using HackatonFiap.Dominio.Funcionario.Models;

namespace HackatonFiap.Aplicacao.UserCases
{
    public class FuncionarioUseCase : IFuncionarioUseCase
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly INotificador _notificador;
        private readonly IMapper _mapper;

        public FuncionarioUseCase(
            IFuncionarioRepository funcionarioRepository,
            INotificador notificador,
            IMapper mapper
            )
        {
            _funcionarioRepository = funcionarioRepository;
            _notificador = notificador;
            _mapper = mapper;
        }

        public async Task<FuncionarioDtoRetorno?> Adicionar(FuncionarioDto funcionarioDto)
        {
            var funcionarioEntity = _mapper.Map<FuncionarioEntity>(funcionarioDto);
            if (!funcionarioEntity.Validacao(_notificador))
            {
                return null;
            }
            
            var funcionarioModel = _mapper.Map<FuncionarioModel>(funcionarioEntity);
            _funcionarioRepository.Adicionar(funcionarioModel);
            
            await _funcionarioRepository.SaveChanges().ConfigureAwait(false);
            return _mapper.Map<FuncionarioDtoRetorno>(funcionarioModel);
        }

        public async Task<FuncionarioDtoRetorno> ObterPorId(Guid id)
        {
            var funcionario = await _funcionarioRepository.Obter(f => f.Id == id).ConfigureAwait(false);
            return _mapper.Map<FuncionarioDtoRetorno>(funcionario);
        }

        public async Task<ListaPaginada<FuncionarioDtoRetorno>> Listar(string filtro = "", string ordenacao = "id asc", int pagina = 1, int qtdeRegistros = 10)
        {
            var funcionarios = await _funcionarioRepository.Buscar(filtro, ordenacao, pagina, qtdeRegistros).ConfigureAwait(false);

            return _mapper.Map<ListaPaginada<FuncionarioDtoRetorno>>(funcionarios);
        }

        public async Task<FuncionarioDtoRetorno?> Excluir(Guid id)
        {
            var funcionarioModel = await _funcionarioRepository.ObterTracking(f => f.Id == id).ConfigureAwait(false);
            
            if (funcionarioModel == null)
            {
                _notificador.Notificar("Registro não encontrado");
                return null;
            }
            
            _funcionarioRepository.Remover(funcionarioModel);
            await _funcionarioRepository.SaveChanges().ConfigureAwait(false);
            return _mapper.Map<FuncionarioDtoRetorno>(funcionarioModel);
        }

        public async Task<FuncionarioDtoRetorno?> Atualizar(FuncionarioDto funcionarioDto)
        {
            var funcionarioModel = await _funcionarioRepository.ObterTracking(f => f.Id == funcionarioDto.Id).ConfigureAwait(false);

            if (funcionarioModel == null)
            {
                _notificador.Notificar("Registro não encontrado");
                return null;
            }
            
            var funcionarioEntity = _mapper.Map<FuncionarioEntity>(funcionarioModel);
            _mapper.Map(funcionarioDto, funcionarioEntity);
            if (!funcionarioEntity.Validacao(_notificador))
            {
                return null;
            }
            
            _mapper.Map(funcionarioEntity, funcionarioModel);
            _funcionarioRepository.Atualizar(funcionarioModel);
            
            await _funcionarioRepository.SaveChanges().ConfigureAwait(false);
            return _mapper.Map<FuncionarioDtoRetorno>(funcionarioModel);
        }
    }
}
