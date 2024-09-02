using YoutubeApi.Application.Bases;

namespace YoutubeApi.Application.Features.Auth.Exceptions
{
    public class UserOrPasswordShouldNotBeInvalidException : BaseException
    {
        public UserOrPasswordShouldNotBeInvalidException() : base("Kullanıcı adı veya şifre yalnıştır. ") { }
    }
}
