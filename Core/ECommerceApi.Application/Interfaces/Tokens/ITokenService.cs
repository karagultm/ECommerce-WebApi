using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ECommerceApi.Domain.Entities;

namespace ECommerceApi.Application.Interfaces.Tokens
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> CreateToken(User user, IList<string> roles);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
    }
}
