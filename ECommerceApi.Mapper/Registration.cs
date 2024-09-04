using Microsoft.Extensions.DependencyInjection;
using ECommerceApi.Application.Interfaces.AutoMapper;

namespace ECommerceApi.Mapper
{
    public static class Registration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, AutoMapper.Mapper>();
        }
    }
}
