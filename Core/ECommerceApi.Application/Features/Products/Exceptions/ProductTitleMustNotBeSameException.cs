using ECommerceApi.Application.Bases;

namespace ECommerceApi.Application.Features.Products.Exceptions
{
    public class ProductTitleMustNotBeSameException : BaseException
    {
        public ProductTitleMustNotBeSameException() : base("Ürün başlığı zaten var!") { }
    }
}
