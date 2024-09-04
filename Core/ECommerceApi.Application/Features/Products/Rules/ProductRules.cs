using ECommerceApi.Application.Bases;
using ECommerceApi.Application.Features.Products.Exceptions;
using ECommerceApi.Domain.Entities;

namespace ECommerceApi.Application.Features.Products.Rules
{
    public class ProductRules : BaseRules
    {
        public Task ProductTitleMustNotBeSame( IList<Product> products, string requestTitle)
        {
            if (products.Any(x => x.Title == requestTitle)) throw new ProductTitleMustNotBeSameException();
            return Task.CompletedTask;
        }
    }
}
