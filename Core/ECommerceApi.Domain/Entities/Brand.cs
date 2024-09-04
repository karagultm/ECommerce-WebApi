using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApi.Domain.Common;

namespace ECommerceApi.Domain.Entities
{
    public class Brand : EntityBase
    {
        //burada IEntityBase yazsan da olur yazmasan da sonuçta entitybase
        //ientitybaseden kalıtım aldığından dolayı dolaylı olarak oda kalıtım alıyor

        public Brand()
        {

        }
        public Brand(string name)
        {
            Name = name;
        }
        public  string Name { get; set; }
    }
}
