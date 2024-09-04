using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Reflection;
using ECommerceApi.Application.Bases;
using ECommerceApi.Application.Behaviors;
using ECommerceApi.Application.Exceptions;
using ECommerceApi.Application.Features.Products.Rules;

namespace ECommerceApi.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();

            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules)); 
            // bude baseruledan türeyenlerin typelarını vememi sağlayağcak

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);

            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RedisCacheBehavior<,>));
             
        }
        private static IServiceCollection AddRulesFromAssemblyContaining(
            this IServiceCollection services,
            Assembly assembly, Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)        //buradaki type != t ile type baserules olmasın diyoruz
                services.AddTransient(item); // BU SAYEDE HER RULE U TEK TEK ELE EKLEMEK YERİNE
                                             // BU FONKSİYON İLE BİRLKTE REGİSTREATİON CLASSIMIZIN
                                             // İÇERSİİNE EKLEYEBİLECEĞİZ

            return services;
        }
    }
}
