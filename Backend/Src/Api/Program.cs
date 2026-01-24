using Application.Services.User;
using Application.Validators;
using Domain.Contracts.Repository.UserRepository;
using Domain.Contracts.Services;
using Domain.Dtos.Requests.CreateUser;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infra;
using Infra.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidatorsFromAssemblyContaining<CreateUserRequest>();


builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();

var connectionString = builder.Configuration.GetConnectionString("Default");

// Register all validators in the assembly containing UserValidator
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

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
app.UseAuthorization();

app.MapControllers();

app.Run();
