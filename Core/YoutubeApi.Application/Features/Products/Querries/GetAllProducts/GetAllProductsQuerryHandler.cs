using MediatR;
using YoutubeApi.Application.Interfaces.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Products.Querries.GetAllProducts
{
    internal class GetAllProductsQuerryHandler : IRequestHandler<GetAllProductsQuerryRequest, IList<GetAllProductsQuerryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllProductsQuerryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IList<GetAllProductsQuerryResponse>> Handle(GetAllProductsQuerryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();

            List<GetAllProductsQuerryResponse> response = new();

            foreach (var product in products)
                response.Add(new GetAllProductsQuerryResponse
                    {
                        Description = product.Description,
                        Title = product.Title,
                        Price = product.Price - (product.Price * product.Discount / 100),
                        Discount = product.Discount,
                    });
            return response;
        }
    }
}
