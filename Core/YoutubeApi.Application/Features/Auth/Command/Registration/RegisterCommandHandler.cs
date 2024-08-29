using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using YoutubeApi.Application.Bases;
using YoutubeApi.Application.Features.Auth.Rules;
using YoutubeApi.Application.Interfaces.AutoMapper;
using YoutubeApi.Application.Interfaces.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Auth.Command.Registration
{
    public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;

        public RegisterCommandHandler(AuthRules authRules, UserManager<User> userManager, RoleManager<Role> roleManager,
            IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
            : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await authRules.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email)); //requestteki email ile birlikte user manager aracılığıyla
                                                                                                     //yani dotnet core un eklentisiyle birlikte userı buluyoruz

            User user = mapper.Map<User, RegisterCommandRequest>(request);
            user.UserName = request.Email;
            user.SecurityStamp = Guid.NewGuid().ToString(); // bu security stamp değerinin amacı şu aslında.
                                                            // misal aynı anda aynı kişi bir şeyde değişiklik yapmak istiyor.
                                                            // biri diğerinde mili saniyelerle önce tıklamış olacaktır.
                                                            // tamam mıyız buraya kadar. bundan sonra bu tıklama ile buradaki
                                                            // security stamp değeri değişecektir. bir sonraki kişi de tıkladığında
                                                            // bu security stamplar aynı olmadığından iş yapamayacak. eğer security
                                                            // stamp olmasa ikinci kişi değişiklik üzerine değişikliği bilmeden değişiklik
                                                            // yapmış olacaktı. buda sistemi patlatacaktı.

            IdentityResult result = await userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                if (!await roleManager.RoleExistsAsync("user"))
                    await roleManager.CreateAsync(new Role
                    {
                        Id = Guid.NewGuid(),
                        Name = "user",
                        NormalizedName = "USER",
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                    });

                await userManager.AddToRoleAsync(user, "user");

            }

            return Unit.Value;
        }
    }
}
