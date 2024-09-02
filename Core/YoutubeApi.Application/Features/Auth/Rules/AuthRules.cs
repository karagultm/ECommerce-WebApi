using YoutubeApi.Application.Bases;
using YoutubeApi.Application.Features.Auth.Exceptions;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Auth.Rules
{
    public class AuthRules : BaseRules
    {
        public Task UserShouldNotBeExist(User? user)
        {
            if (user is not null) throw new UserAlreadyExistException(); //user kayıtlı ise yani exception fırlat diyoruz kısacası.
            return Task.CompletedTask;
        }

        public Task UserOrPasswordShouldNotBeInvalid(User? user, bool checkPassword)
        {
            if (user is null || !checkPassword) throw new UserOrPasswordShouldNotBeInvalidException();
            return Task.CompletedTask;
        }
    }
}
