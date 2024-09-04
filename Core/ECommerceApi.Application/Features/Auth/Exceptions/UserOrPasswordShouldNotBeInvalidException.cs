using ECommerceApi.Application.Bases;

namespace ECommerceApi.Application.Features.Auth.Exceptions
{
    public class UserOrPasswordShouldNotBeInvalidException : BaseException
    {
        public UserOrPasswordShouldNotBeInvalidException() : base("Kullanıcı adı veya şifre yalnıştır. ") { }
    }
}
