using MediatR;

namespace YoutubeApi.Application.Features.Auth.Command.Registration
{
    public class RegisterCommandRequest : IRequest<Unit>
    //bu requestimizin bir outu olsun ki pipeline behaviour da
    //fluent validation da yani validation a sokalım. bu amaçtan
    //dolayı requeste bunu ekliyoruz
    {

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
