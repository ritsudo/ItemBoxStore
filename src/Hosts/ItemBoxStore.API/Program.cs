using ItemBoxStore.Application.Contexts.Item.Services.Definitions;
using ItemBoxStore.Application.Contexts.Item.Services.Implementations;
using ItemBoxStore.Application.Contexts.User.Services;
using ItemBoxStore.Application.Contexts.User.Services.Definitions;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Infrastructure;
using ItemBoxStore.Infrastructure.DataAccess.Repositories;
using ItemBoxStore.Infrastructure.DataAccess.Repositories.Items;
using ItemBoxStore.Infrastructure.Identity;
using ItemBoxStore.Infrastructure.PasswordHasher;
using ItemBoxStore.Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddServices();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IStorageFileService, StorageFileService>();
builder.Services.AddTransient<IItemService, ItemService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IStorageFileRepository, StorageFileRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection")));
builder.Services.AddScoped<DbContext>(s => s.GetRequiredService<ApplicationDbContext>());

builder.Services.AddTransient<IItemService, ItemService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(gen =>
{
    gen.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API - магазин", Version = "V1" });
    var xmlFilePath = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilePath);
    gen.IncludeXmlComments(xmlPath);
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        options.SlidingExpiration = true;
        options.Events.OnSignedIn = context =>
        {
            //add log info
            return Task.CompletedTask;
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();

    options.AddPolicy("MyPolicy", policy => policy.RequireClaim("MyClaim"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
