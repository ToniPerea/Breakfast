using CoffeShopApi.Models;
using CoffeShopApi.Services;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
  options.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {
                      policy.WithOrigins("http://localhost:3000")
                        .WithMethods("PUT", "DELETE", "GET", "POST")
                        .AllowAnyHeader();
                    });
});

// Add services to the container.
builder.Services.Configure<CoffeShopDatabaseSettings>(
    builder.Configuration.GetSection("CoffeShopDatabase"));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// builder.Services.AddSingleton<SesionsService>();
builder.Services.AddSingleton<BreakfastsService>();
builder.Services.AddSingleton<MealsService>();
builder.Services.AddSingleton<DrinksService>();
// builder.Services.AddSingleton<SesionsBreakfastsService>();

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
