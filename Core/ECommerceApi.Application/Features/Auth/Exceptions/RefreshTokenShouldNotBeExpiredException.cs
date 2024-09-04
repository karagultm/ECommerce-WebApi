using ECommerceApi.Application.Bases;

namespace ECommerceApi.Application.Features.Auth.Exceptions
{
    public class RefreshTokenShouldNotBeExpiredException : BaseException
    {

        public RefreshTokenShouldNotBeExpiredException() : base("Oturum süresi sona ermiştir. Lütfen tekrar giriş yapınız.") { }
        // bu bize özel bir exception fırlatmamıza olanak sağlıyor.

    }
}
