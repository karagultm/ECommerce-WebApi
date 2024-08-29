using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using YoutubeApi.Application.Interfaces.AutoMapper;
using YoutubeApi.Application.Interfaces.UnitOfWorks;

namespace YoutubeApi.Application.Bases
{
    public class BaseHandler
    {
        // base handler sınıfımız ile birlikte her handler sınıfımızda tek tek constructurlarda
        // mapperleri unit of workleri çağırmakla uğraşmıyoruz.
        public readonly IMapper mapper;
        public readonly IUnitOfWork unitOfWork;
        public readonly IHttpContextAccessor httpContextAccessor;
        public readonly string userId;
        public BaseHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
            userId = httpContextAccessor.HttpContext
                .User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
