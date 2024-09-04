using MediatR;

namespace ECommerceApi.Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
