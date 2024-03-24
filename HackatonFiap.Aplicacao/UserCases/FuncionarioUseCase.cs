using AutoMapper;
using HackatonFiap.Aplicacao.Interfaces;
using HackatonFiap.Aplicacao.Interfaces.Integracao;
using HackatonFiap.Comum;
using HackatonFiap.Comum.Notificacoes;
using HackatonFiap.Dominio.Funcionario.Dtos;
using HackatonFiap.Dominio.Funcionario.Entities;
using HackatonFiap.Dominio.Funcionario.Models;
using HackatonFiap.Dominio.Integracao.Cognito.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HackatonFiap.Aplicacao.UserCases
{
    public class FuncionarioUseCase : IFuncionarioUseCase
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly ICognitoRepository _cognitoRepository;
        private readonly IConfiguration _configuration;
        private readonly INotificador _notificador;
        private readonly IMapper _mapper;
        private readonly ILogger<FuncionarioUseCase> _logger;

        public FuncionarioUseCase(
            IFuncionarioRepository funcionarioRepository,
            ICognitoRepository cognitoRepository,
            IConfiguration configuration,
            INotificador notificador,
            IMapper mapper,
            ILogger<FuncionarioUseCase> logger)
        {
            _funcionarioRepository = funcionarioRepository;
            _cognitoRepository = cognitoRepository;
            _configuration = configuration;
            _notificador = notificador;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<FuncionarioDtoRetorno?> Adicionar(FuncionarioDto funcionarioDto)
        {
            var chave = Guid.NewGuid();
            await _funcionarioRepository.BeginTransactionAsync(chave);
            try
            {
                var funcionarioEntity = _mapper.Map<FuncionarioEntity>(funcionarioDto);
                if (!funcionarioEntity.Validacao(_notificador))
                {
                    return null;
                }
            
                var funcionarioModel = _mapper.Map<FuncionarioModel>(funcionarioEntity);
                _funcionarioRepository.Adicionar(funcionarioModel);
            
                await _funcionarioRepository.SaveChanges().ConfigureAwait(false);

                var respCog = await _cognitoRepository.Adicionar(new CognitoUserModel
                {
                    Email = funcionarioModel.Email,
                    Password = _configuration["SenhaPadrao"] ?? "Fiap@123",
                    Name = funcionarioModel.Nome
                        
                });

                if (respCog == null)
                {
                    await _funcionarioRepository.RollbackAsync(chave);
                    _notificador.Notificar("Não foi possível adicionar o funcionário!");
                    return null;
                }
                
                funcionarioModel.CognitoId = respCog.UserSub;
                _funcionarioRepository.Atualizar(funcionarioModel);
                await _funcionarioRepository.SaveChanges().ConfigureAwait(false);
                
                await _funcionarioRepository.CommitAsync(chave);
                return _mapper.Map<FuncionarioDtoRetorno>(funcionarioModel);
            }
            catch (Exception e)
            {
                await _funcionarioRepository.RollbackAsync(chave);
                _notificador.Notificar("Não foi possível adicionar o funcionário!");
                _logger.LogError(e, "{Message}, {InnerException}, {StackTrace}", e.Message, e.InnerException?.Message,e.StackTrace);
                return null;
            }
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