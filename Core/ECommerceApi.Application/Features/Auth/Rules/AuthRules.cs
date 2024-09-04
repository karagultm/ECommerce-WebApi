using ECommerceApi.Application.Bases;
using ECommerceApi.Application.Features.Auth.Exceptions;
using ECommerceApi.Domain.Entities;

namespace ECommerceApi.Application.Features.Auth.Rules
{
    public class AuthRules : BaseRules
    {
        public Task UserShouldNotBeExist(User? user)
        {
            if (user is not null) throw new UserAlreadyExistException(); //user kayıtlı ise yani exception fırlat diyoruz kısacası.
            return Task.CompletedTask;
        }

        public Task EmailOrPasswordShouldNotBeInvalid(User? user, bool checkPassword)
        {
            if (user is null || !checkPassword) throw new UserOrPasswordShouldNotBeInvalidException();
            return Task.CompletedTask;
        }
        public Task RefreshTokenShouldNotBeExpired(DateTime? expiryTime)
        {
            if (expiryTime <= DateTime.Now) throw new RefreshTokenShouldNotBeExpiredException();
            return Task.CompletedTask;
        }

        public Task EmailAddressShouldBeValid(User? user)
        {
            if (user is null) throw new EmailAddressShouldBeValidException();
            return Task.CompletedTask;
        }
    }
}
