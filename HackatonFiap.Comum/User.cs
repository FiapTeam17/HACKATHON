using System.Security.Claims;
using HackatonFiap.Comum.Interfaces;
using Microsoft.AspNetCore.Http;

namespace HackatonFiap.Comum;

public class User : IUser
{
    private readonly IHttpContextAccessor _accessor;

    public User(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    } 

    public string? Name => _accessor.HttpContext?.User.Identity?.Name;

    public string GetUserId()
    {
        if(_accessor.HttpContext == null)
            return string.Empty;
            
        return IsAuthenticated() ? _accessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty : string.Empty;
    }

    public string? GetUserEmail()
    {
        if(_accessor.HttpContext == null)
            return string.Empty;
            
        return IsAuthenticated() ? _accessor.HttpContext.User?.FindFirst(ClaimTypes.Email)?.Value : string.Empty;
    }

    public string? GetUserNome()
    {
        if(_accessor.HttpContext == null)
            return string.Empty;
            
        return IsAuthenticated() ? _accessor?.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type.Equals("name"))?.Value : string.Empty;
    }

    public bool IsAuthenticated()
    {
        return _accessor?.HttpContext?.User?.Identity is { IsAuthenticated: true };
    }

    public bool IsInRole(string role)
    {
        return _accessor?.HttpContext != null && _accessor.HttpContext.User.IsInRole(role);
    }
        
    public bool IsInRole(string role, string valor)
    {
        if (_accessor?.HttpContext == null)
            return false;
            
        var claim = _accessor?.HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type.Equals(role));

        return claim != null && claim.Value.Equals(valor);
    }

    public IEnumerable<Claim>? GetClaimsIdentity()
    {
        return _accessor.HttpContext?.User?.Claims;
    }
}