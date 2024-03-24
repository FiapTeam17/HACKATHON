using System.Security.Claims;

namespace HackatonFiap.Comum.Interfaces;

public interface IUser
{
    string? Name { get; }
    string GetUserId();
    string? GetUserEmail();
    string? GetUserNome();
    bool IsAuthenticated();
    bool IsInRole(string role);
    bool IsInRole(string role, string valor);
    IEnumerable<Claim>? GetClaimsIdentity();
}