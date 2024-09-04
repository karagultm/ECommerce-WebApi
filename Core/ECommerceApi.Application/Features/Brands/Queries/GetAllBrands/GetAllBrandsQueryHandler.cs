using MediatR;
using Microsoft.AspNetCore.Http;
using ECommerceApi.Application.Bases;
using ECommerceApi.Application.Interfaces.AutoMapper;
using ECommerceApi.Application.Interfaces.UnitOfWorks;
using ECommerceApi.Domain.Entities;

namespace ECommerceApi.Application.Features.Brands.Queries.GetAllBrands
{
    public class GetAllBrandsQueryHandler : BaseHandler, IRequestHandler<GetAllBrandsQueryRequest, IList<GetAllBrandsQueryResponse>>
    {
        public GetAllBrandsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<IList<GetAllBrandsQueryResponse>> Handle(GetAllBrandsQueryRequest request, CancellationToken cancellationToken)
        {
            var brands = await unitOfWork.GetReadRepository<Brand>().GetAllAsync();

            return mapper.Map<GetAllBrandsQueryResponse, Brand>(brands);
        }
    }
}
