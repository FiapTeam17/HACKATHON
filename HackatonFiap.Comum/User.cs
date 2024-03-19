using System.Security.Claims;
using HackatonFiap.Comum.Extensions;
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

    public Guid GetUserId()
    {
        if(_accessor.HttpContext == null)
            return Guid.Empty;
            
        return IsAuthenticated() ? Guid.Parse(_accessor.HttpContext.User.GetUserId() ?? string.Empty) : Guid.Empty;
    }

    public string? GetUserEmail()
    {
        if(_accessor.HttpContext == null)
            return string.Empty;
            
        return IsAuthenticated() ? _accessor.HttpContext.User.GetUserEmail() : string.Empty;
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