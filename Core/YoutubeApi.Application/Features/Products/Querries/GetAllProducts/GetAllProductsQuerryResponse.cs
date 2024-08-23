using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeApi.Application.Features.Products.Querries.GetAllProducts
{
    internal class GetAllProductsQuerryResponse
    {
        //bu response sınıfı aslında dto sınıfla viewmodel kısmıyla aynı işlevi gösteriyor
        //kullanıcıya gidipte misal producttan özel bilgileri vermiyoruz. 
        //sadece istediğimiz verileri veriyoruz.

        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}
