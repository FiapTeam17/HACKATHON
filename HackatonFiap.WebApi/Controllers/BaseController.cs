using HackatonFiap.Comum;
using HackatonFiap.Comum.Interfaces;
using HackatonFiap.Comum.Notificacoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HackatonFiap.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly INotificador Notificador;
        protected readonly IUser AppUser;

        protected Guid UsuarioId { get; set; }
        protected bool UsuarioAutenticado { get; set; }

        protected BaseController(INotificador notificador, IUser appUser)
        {
            Notificador = notificador;
            AppUser = appUser;

            if (appUser.IsAuthenticated())
            {
                UsuarioId = appUser.GetUserId();
                UsuarioAutenticado = true;
            }
        }

        protected bool OperacaoValida()
        {
            return !Notificador.TemNotificacao();
        }

        protected ActionResult CustomResponse<T>(T? result = default, bool semRetornoPadrao = false)
        {
            if (OperacaoValida())
            {
                if (semRetornoPadrao)
                {
                    return Ok(result);
                }
                
                return Ok(new RetornoPadrao<T?>
                {
                    Success = true,
                    Data = result
                });
            }

            return BadRequest(new RetornoPadrao<T>
            {
                Success = false,
                Errors = Notificador.ObterNotificacoes().Select(n => n.Mensagem).ToList()
            });
        }

        protected ActionResult CustomResponseComDataNoErro<T>(T? result = default, bool semRetornoPadrao = false)
        {
            if (OperacaoValida())
            {
                if (semRetornoPadrao)
                {
                    return Ok(result);
                }
                
                return Ok(new RetornoPadrao<T?>
                {
                    Success = true,
                    Data = result
                });
            }

            return BadRequest(new RetornoPadrao<T?>()
            {
                Success = false,
                Errors = Notificador.ObterNotificacoes().Select(n => n.Mensagem).ToList(),
                Data = result
            });
        }
        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) 
                NotificarErroModelInvalida(modelState);
            
            return CustomResponse(true);
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(errorMsg);
            }
        }

        protected void NotificarErro(string mensagem)
        {
            Notificador.Notificar(new Notificacao(mensagem));
        }


    }
}
