using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PasswordManager.Application;
using PasswordManager.Application.Features.AuthFeature.QueryHandlers;
using PasswordManager.Application.Features.AuthFeature.Validators;
using PasswordManager.Application.Features.PasswordFeature.Queries;
using PasswordManager.Application.Features.PasswordFeature.QueriesHandlers;
using PasswordManager.Application.Features.UserFeature.Validators;
using PasswordManager.Application.Helpers;
using PasswordManager.Application.Interfaces;
using PasswordManager.Application.Mapping;
using PasswordManager.Domain.Interfaces;
using PasswordManager.Domain.Models.Tables;
using PasswordManager.Infrastructure;
using PasswordManager.Infrastructure.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
	.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RegisterRequestValidator>());
builder.Services.AddControllers()
	.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserRequestValidator>());

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();



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

builder.Services.AddScoped(typeof(IRepositoryBase<>),typeof(Repository<>));
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IRequestHandler<GetPasswordByIdQuery, Password>, GetPasswordByIdQueryHandler>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LoginUserQueryHandler).Assembly));

builder.Services.AddAutoMapper(typeof(UserProfile)); // AutoMapper servisi
builder.Services.AddAutoMapper(typeof(PasswordProfile));

builder.Services.AddApplication().AddInfrastructure();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

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