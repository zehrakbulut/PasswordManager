using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PasswordManager.Application;
using PasswordManager.Application.Features.AuthFeature.QueryHandlers;
using PasswordManager.Application.Features.PasswordFeature.Queries;
using PasswordManager.Application.Features.PasswordFeature.QueriesHandlers;
using PasswordManager.Application.Helpers;
using PasswordManager.Application.Interfaces;
using PasswordManager.Application.Mapping;
using PasswordManager.Domain.Interfaces;
using PasswordManager.Domain.Models.Tables;
using PasswordManager.Infrastructure;
using PasswordManager.Infrastructure.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// JWT konfigürasyonu
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var key = Encoding.UTF8.GetBytes(jwtSettings["Secret"]);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidIssuer = jwtSettings["Issuer"],
			ValidAudience = jwtSettings["Audience"],
			IssuerSigningKey = new SymmetricSecurityKey(key)
		};
	});

builder.Services.AddAuthorization();


builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IRepositoryBase<User>, Repository<User>>();
builder.Services.AddScoped<IRepositoryBase<Password>, Repository<Password>>();
builder.Services.AddScoped<IRequestHandler<GetPasswordByIdQuery, Password>, GetPasswordByIdQueryHandler>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LoginUserQueryHandler).Assembly));

builder.Services.AddAutoMapper(typeof(UserProfile)); // AutoMapper servisi
builder.Services.AddAutoMapper(typeof(PasswordProfile));

builder.Services.AddApplication().AddInfrastructure();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "PasswordManager API", Version = "v1" });

	// JWT Authentication için Swagger konfigürasyonu
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Name = "Authorization",
		Type = SecuritySchemeType.Http,
		Scheme = "Bearer",
		BearerFormat = "JWT",
		In = ParameterLocation.Header,
		Description = "JWT tokenınızı 'Bearer {token}' formatında girin. Örnek: Bearer abcdef12345"
	});

	c.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = "Bearer"
				}
			},
			new List<string>()
		}
	});
});

//Add DbContext
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

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