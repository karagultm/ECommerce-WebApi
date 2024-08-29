using YoutubeApi.Application.DTOs;

namespace YoutubeApi.Application.Features.Products.Queries.GetAllProducts
{
    internal class GetAllProductsQueryResponse
    {
        //bu response sınıfı aslında dto sınıfla viewmodel kısmıyla aynı işlevi gösteriyor
        //kullanıcıya gidipte misal producttan özel bilgileri vermiyoruz. 
        //sadece istediğimiz verileri veriyoruz.

        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public BrandDto Brand { get; set; }
    }
}
