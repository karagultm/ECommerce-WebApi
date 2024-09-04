using MediatR;
using Microsoft.AspNetCore.Http;
using ECommerceApi.Application.Bases;
using ECommerceApi.Application.Features.Products.Rules;
using ECommerceApi.Application.Interfaces.AutoMapper;
using ECommerceApi.Application.Interfaces.UnitOfWorks;
using ECommerceApi.Domain.Entities;

namespace ECommerceApi.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : BaseHandler, IRequestHandler<CreateProductCommandRequest, Unit>

    {
        private readonly ProductRules productRules;

        public CreateProductCommandHandler(ProductRules productRules, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.productRules = productRules;
        }
        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Product> products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();

            Product product = new(request.Title, request.Description, request.BrandId, request.Price, request.Discount);

            await productRules.ProductTitleMustNotBeSame(products, request.Title);

            await unitOfWork.GetWriteRepository<Product>().AddAsync(product);
            if (await unitOfWork.SaveAsync() > 0) // buradaki saveasync bu untofwork de kaç tane başarılı işlem dödüğünü
                                                  // int olarak döndürür. yani üstteki satır doğru çalışırsa 1 olur işlemin sonucu
            {
                foreach (var categoryId in request.CategoryIds)
                    await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                    {
                        ProductId = product.Id,
                        CategoryId = categoryId
                    });
                await unitOfWork.SaveAsync();
            }

            return Unit.Value;

        }
    }
}
