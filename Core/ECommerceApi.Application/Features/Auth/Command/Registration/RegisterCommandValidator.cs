using FluentValidation;

namespace ECommerceApi.Application.Features.Auth.Command.Registration
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
    //burada validasyon işlemlerimizi gerçekleştiriyoruz
    {
        //validasyonlarımızı constructor içerisinde gerçekleştiriyoruz
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(2)
                .WithName("İsim Soyisim");

            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(60)
                .MinimumLength(2)
                .EmailAddress()
                .WithName("E-posta Adresi");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6)
                .WithName("Parola");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .MinimumLength(6)
                .Equal(x => x.Password)
                .WithName("Parola Tekrarı");
        }
    }
}
