using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApi.Application.Interfaces.RedisCache;

namespace ECommerceApi.Application.Features.Brands.Queries.GetAllBrands
{
    public class GetAllBrandsQueryRequest : IRequest<IList<GetAllBrandsQueryResponse>>, ICacheableQuerry
    {
        public string CacheKey => "GetAllBrands";

        public double CacheTime => 10;
    }
}
