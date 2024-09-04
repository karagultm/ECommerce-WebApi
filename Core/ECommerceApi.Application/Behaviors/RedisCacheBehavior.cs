using MediatR;
using ECommerceApi.Application.Interfaces.RedisCache;

namespace ECommerceApi.Application.Behaviors
{
    public class RedisCacheBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IRedisCacheService redisCacheService;

        public RedisCacheBehavior(IRedisCacheService redisCacheService)
        {
            this.redisCacheService = redisCacheService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            if (request is ICacheableQuerry querry)
            {
                var cacheKey = querry.CacheKey;
                var cacheTime = querry.CacheTime;
                //bizim databaseden çekiyor get async
                var cachedData = await redisCacheService.GetAsync<TResponse>(cacheKey); //benim redis serviceimden veriyi çekiyorum
                if (cachedData is not null) //eğer cache in içi doluysa döndür değilse doldur içini işlemini yapıyoruz
                    return cachedData;

                var response = await next();
                if (response is not null )
                    await redisCacheService.SetAsync(cacheKey, response, DateTime.Now.AddMinutes(cacheTime)); 
                //bu son cachetime ile cahcete nekadar kalacağını hesaplatıyoruz

                return response;
            }
            return await next();


        }
    }
}
