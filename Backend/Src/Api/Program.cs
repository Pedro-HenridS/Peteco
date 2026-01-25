using Application.Services.Password;
using Application.Services.User;
using Application.UseCases.CreateUser;
using Application.UseCases.Login;
using Application.Validators;
using Domain.Contracts.Providers;
using Domain.Contracts.Repository.AddressRepository;
using Domain.Contracts.Repository.UserRepository;
using Domain.Contracts.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infra;
using Infra.Providers.JwtToken;
using Infra.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();

var connectionString = builder.Configuration.GetConnectionString("Default");

// Register all validators in the assembly containing UserValidator
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();

builder.Services.AddScoped<IUserService, UserService>();

//Services
builder.Services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();

//Use Case
builder.Services.AddScoped<CreateUserUseCase>();
builder.Services.AddScoped<LoginUseCase>();

//Repository
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString),
        mysql =>
        {
            mysql.EnableRetryOnFailure();
            mysql.CommandTimeout(30);
        }
    )
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
