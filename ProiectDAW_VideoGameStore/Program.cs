using Microsoft.EntityFrameworkCore;
using ProiectDAW_VideoGameStore.Data;
using ProiectDAW_VideoGameStore.Helpers.Extensions;
using ProiectDAW_VideoGameStore.Helpers;
using ProiectDAW_VideoGameStore.Helpers.Seeders;

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        var itemService = scope.ServiceProvider.GetService<StoreItemSeeder>();
        itemService.SeedInitialItems();
    }
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowSpecificOrigins", policy =>
    {
        policy.AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials()
               .WithOrigins("http://localhost:5174");
    });
});

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddHelpers();
builder.Services.AddSeeders();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyAllowSpecificOrigins");

SeedData(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
