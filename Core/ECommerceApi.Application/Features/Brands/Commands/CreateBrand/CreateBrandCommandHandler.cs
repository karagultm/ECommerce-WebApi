using Bogus;
using MediatR;
using Microsoft.AspNetCore.Http;
using ECommerceApi.Application.Bases;
using ECommerceApi.Application.Interfaces.AutoMapper;
using ECommerceApi.Application.Interfaces.UnitOfWorks;
using ECommerceApi.Domain.Entities;

namespace ECommerceApi.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandHandler : BaseHandler, IRequestHandler<CreateBrandCommandRequest, Unit>
    {
        public CreateBrandCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            Faker faker = new("tr");
            List<Brand> brands = new();

            for (int i = 0; i <1000000; i++)
            {
                brands.Add(new(faker.Commerce.Department(1)));
            }
            await unitOfWork.GetWriteRepository<Brand>().AddRangeAsync(brands);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
