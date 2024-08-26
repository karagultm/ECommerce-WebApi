using MediatR;
using Microsoft.EntityFrameworkCore;
using YoutubeApi.Application.DTOs;
using YoutubeApi.Application.Interfaces.AutoMapper;
using YoutubeApi.Application.Interfaces.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Products.Querries.GetAllProducts
{
    internal class GetAllProductsQuerryHandler : IRequestHandler<GetAllProductsQuerryRequest, IList<GetAllProductsQuerryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllProductsQuerryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllProductsQuerryResponse>> Handle(GetAllProductsQuerryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(include: x => x.Include(b=>b.Brand));

            //List<GetAllProductsQuerryResponse> response = new();

            //foreach (var product in products)
            //    response.Add(new GetAllProductsQuerryResponse
            //        {
            //            Description = product.Description,
            //            Title = product.Title,
            //            Price = product.Price - (product.Price * product.Discount / 100),
            //            Discount = product.Discount,
            //        });
            //return response;

            var brand = mapper.Map<BrandDto, Brand>(new Brand());
            
            var map = mapper.Map<GetAllProductsQuerryResponse, Product>(products);
            foreach (var item in map)
                item.Price -= (item.Price * item.Discount / 100);

            return map;
        }
    }
}
