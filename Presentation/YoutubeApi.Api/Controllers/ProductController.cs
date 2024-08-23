using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YoutubeApi.Application.Features.Products.Querries.GetAllProducts;

namespace YoutubeApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        //eğer route kısında /action yazmazsam burada httpget te
        //[HttpGet "GetAllProducts"] şekilinde routue u vermem gerekirdi
        //şimdi ise direkt olarak action ın adını kendisi alıcak
        //alttaki fonksiyon bakarsan action türünde görürsün

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await mediator.Send(new GetAllProductsQuerryRequest());

            return Ok(response);

        }
    }
}
