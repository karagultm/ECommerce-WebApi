using MediatR;
using Microsoft.AspNetCore.Mvc;
using ECommerceApi.Application.Features.Auth.Command.Login;
using ECommerceApi.Application.Features.Auth.Command.RefreshToken;
using ECommerceApi.Application.Features.Auth.Command.Registration;
using ECommerceApi.Application.Features.Auth.Command.Revoke;
using ECommerceApi.Application.Features.Auth.Command.RevokeAll;

namespace ECommerceApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created); //register işleminde bir response dönmüyoruz. 
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response); //fakat login işleminde bir response dönüyoruz.
        }
        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }
        [HttpPost]
        public async Task<IActionResult> Revoke(RevokeCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPost]
        public async Task<IActionResult> RevokeAll()
        {
            await mediator.Send(new RevokeAllCommandRequest()); //buradaki requestler göstermelik olarak varlar aslında.
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
