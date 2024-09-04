using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ECommerceApi.Application.Bases;
using ECommerceApi.Application.DTOs;
using ECommerceApi.Application.Interfaces.AutoMapper;
using ECommerceApi.Application.Interfaces.UnitOfWorks;
using ECommerceApi.Domain.Entities;

namespace ECommerceApi.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : BaseHandler, IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        public GetAllProductsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {

        }
        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(include: x => x.Include(b => b.Brand));

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

            var map = mapper.Map<GetAllProductsQueryResponse, Product>(products);
            foreach (var item in map)
                item.Price -= (item.Price * item.Discount / 100);

            return map;
            //throw new Exception("hata");
        }
    }
}
