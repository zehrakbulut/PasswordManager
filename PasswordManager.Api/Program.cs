using MediatR;
using Microsoft.EntityFrameworkCore;
using PasswordManager.Application;
using PasswordManager.Application.Features.PasswordFeature.Commands;
using PasswordManager.Application.Features.UserFeature.Commands;
using PasswordManager.Application.Mapping;
using PasswordManager.Domain.Interfaces;
using PasswordManager.Infrastructure;
using PasswordManager.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly)); //MediatR kayýt ettim
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreatePasswordCommand).Assembly));

builder.Services.AddAutoMapper(typeof(UserProfile)); // AutoMapper servisi
builder.Services.AddAutoMapper(typeof(PasswordProfile)); 

builder.Services.AddApplication().AddInfrastructure();

builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(Repository<>));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add DbContext
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
