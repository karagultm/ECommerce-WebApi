using MediatR;
using Microsoft.AspNetCore.Mvc;
using ECommerceApi.Application.Features.Brands.Commands.CreateBrand;
using ECommerceApi.Application.Features.Brands.Queries.GetAllBrands;

namespace ECommerceApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator mediator;

        public BrandController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommandRequest request)
        {
            await mediator.Send(request);

            return Ok();

        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var response = await mediator.Send(new GetAllBrandsQueryRequest());

            return Ok(response);

        }
    }
}
