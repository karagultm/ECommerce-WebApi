using YoutubeApi.Application;
using YoutubeApi.Application.Exceptions;
using YoutubeApi.Infrastructure;
using YoutubeApi.Mapper;
using YoutubeApi.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
