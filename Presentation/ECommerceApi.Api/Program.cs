using Microsoft.OpenApi.Models;
using ECommerceApi.Application;
using ECommerceApi.Application.Exceptions;
using ECommerceApi.Infrastructure;
using ECommerceApi.Mapper;
using ECommerceApi.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "E-Commorence API", Version = "v1", Description = "E-Commorence API swagger client" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "'Bearer' yazıp boşluk bıraktıktan sonra Token'ı girebilirisiniz \r\n\r\n Örneğin: \"Bearer e12SDdf233adf^+13341\""
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference()
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var env = builder.Environment; // bu sayede enviromentımın altındaki adı almış olacaklar.

builder.Configuration
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false) // yani bu appsettingsi her koşulda okumam gerekiyor optional değil
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true); //her zaman development yada production ortamını görmek istmeyebilirm

//burada builder servies ı configuration altında yazıyoruz çünkü 
//ilk önce configuration ile hangi enviroment ta olduğumuzu bulsun ondan sonra 
//o environment a göre configuration ını yapsın
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddCustomMapper();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandlingMiddleware(); // bu şekilde middleware ımı applicationıma run time ıma eklemiş oldum

app.UseAuthorization();

app.MapControllers();

app.Run();
