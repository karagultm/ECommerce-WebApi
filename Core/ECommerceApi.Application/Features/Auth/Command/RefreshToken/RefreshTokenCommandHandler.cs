using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ECommerceApi.Application.Bases;
using ECommerceApi.Application.Features.Auth.Rules;
using ECommerceApi.Application.Interfaces.AutoMapper;
using ECommerceApi.Application.Interfaces.Tokens;
using ECommerceApi.Application.Interfaces.UnitOfWorks;
using ECommerceApi.Domain.Entities;

namespace ECommerceApi.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommandHandler : BaseHandler,
        IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
    {
        private readonly ITokenService tokenService;
        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;

        public RefreshTokenCommandHandler(ITokenService tokenService,AuthRules authRules, UserManager<User> userManager,
            IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
            : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.tokenService = tokenService;
            this.authRules = authRules;
            this.userManager = userManager;
        }

        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
             // kısaca kullanıcı girdiği acces ve refresh token ile zamanı geçmemişse oturumunun bunları yenilemeyi sağlıyor.
            ClaimsPrincipal? principal = tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
            string email = principal.FindFirstValue(ClaimTypes.Email);

            User? user = await userManager.FindByEmailAsync(email);
            IList<string> roles = await userManager.GetRolesAsync(user);


            await authRules.RefreshTokenShouldNotBeExpired(user.RefreshTokenExpiryTime); // eğer refresh token expiry time şuandki dateten küçükse hata dönecek

            JwtSecurityToken newAccessToken = await tokenService.CreateToken(user, roles);
            string newRefreshToken =  tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await userManager.UpdateAsync(user);

            return new()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = newRefreshToken,
            };


        }

    }
}
