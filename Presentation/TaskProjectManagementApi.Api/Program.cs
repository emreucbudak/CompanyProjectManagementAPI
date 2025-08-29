using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Design;
using TaskProjectManagementApi.Api.Extensions;
using TaskProjectManagementApi.Application;
using TaskProjectManagementApi.Application.Features.CQRS.Auth.Register;
using TaskProjectManagementApi.Application.Features.CQRS.Auth.Rules;
using TaskProjectManagementApi.Application.Interfaces.Tokens;
using TaskProjectManagementApi.Domain.Entity;
using TaskProjectManagementApi.Infrastructure.Tokens;
using TaskProjectManagementApi.Persistence;
using TaskProjectManagementApi.Persistence.AppDbContext;
using AutoMapper;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServer(builder.Configuration);
builder.Services.ConfigurePersistence();
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    
}).AddJwtBearer(ops =>
{
    ops.Audience = builder.Configuration["Jwt:Audience"];
    ops.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])),
        ClockSkew = TimeSpan.Zero,
        
      
        
    };
});
builder.Services.AddIdentity<User, Role>(options =>
{
    options.Password.RequiredLength = 4;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<RegisterCommandHandler>());
builder.Services.AddScoped<ITokenService,TokenService>();
builder.Services.AddScoped<AuthRules>();
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MapperProfile>());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // JSON endpoint
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskProjectManagement API V1");
        
        c.RoutePrefix = string.Empty; // Tarayýcýyý açýnca direkt Swagger UI gelsin
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
