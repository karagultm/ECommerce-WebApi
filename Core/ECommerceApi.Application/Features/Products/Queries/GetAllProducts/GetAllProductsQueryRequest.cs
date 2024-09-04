using MediatR;
using ECommerceApi.Application.Interfaces.RedisCache;

namespace ECommerceApi.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<IList<GetAllProductsQueryResponse>>, ICacheableQuerry
    {
        public string CacheKey => "GetAllProducts";

        public double CacheTime => 60;
    }
}
 