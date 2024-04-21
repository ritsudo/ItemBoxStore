using FluentValidation;
using FluentValidation.AspNetCore;
using ItemBoxStore.Application.Contexts.Item.Services.Definitions;
using ItemBoxStore.Application.Contexts.Item.Services.Implementations;
using ItemBoxStore.Application.Contexts.User.Services;
using ItemBoxStore.Application.Contexts.User.Services.Definitions;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Application.Validators;
using ItemBoxStore.Infrastructure;
using ItemBoxStore.Infrastructure.DataAccess.Repositories;
using ItemBoxStore.Infrastructure.DataAccess.Repositories.Items;
using ItemBoxStore.Infrastructure.PasswordHasher;
using ItemBoxStore.Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;
using System.Text;

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
    gen.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API - �������", Version = "V1" });
    var xmlFilePath = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilePath);
    gen.IncludeXmlComments(xmlPath);

    gen.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                        Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n
                        Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = JwtBearerDefaults.AuthenticationScheme
    });

    gen.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
    });
});


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {

        options.RequireHttpsMetadata = true;
        options.SaveToken = true;
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    }
    );

builder.Services.AddAuthorization();

builder.Services.AddSerilog((services, config) =>
{
    config
        .ReadFrom.Configuration(builder.Configuration)
        .WriteTo.Console();
});

builder.Services.AddFluentValidationAutoValidation(o => o.DisableDataAnnotationsValidation = true);
builder.Services.AddValidatorsFromAssemblies([
        typeof(CreateItemValidator).Assembly,
        typeof(RegisterUserValidator).Assembly
    ]);

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
