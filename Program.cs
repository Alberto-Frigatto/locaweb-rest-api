using Microsoft.EntityFrameworkCore;
using locaweb_rest_api.Data.Contexts;
using locaweb_rest_api.Services;
using locaweb_rest_api.Services.Impl;
using locaweb_rest_api.Repositories;
using locaweb_rest_api.Repositories.Impl;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;
using locaweb_rest_api.ViewModels.In;
using locaweb_rest_api.ViewModels.Out;
using locaweb_rest_api.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(
    opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
);

var mapperConfig = new MapperConfiguration(c =>
{
    c.AllowNullCollections = true;
    c.AllowNullDestinationValues = true;

    c.CreateMap<InCreateUserViewModel, User>();
    c.CreateMap<User, OutUserViewModel>();

    c.CreateMap<ReceivedEmail, OutReceivedEmailViewModel>();

    c.CreateMap<SentEmail, OutSentEmailViewModel>();
});

IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IDeletedReceivedEmailRepository, DeletedReceivedEmailRepository>();
builder.Services.AddScoped<IFavoriteReceivedEmailRepository, FavoriteReceivedEmailRepository>();
builder.Services.AddScoped<IReceivedEmailRepository, ReceivedEmailRepository>();
builder.Services.AddScoped<ISentEmailRepository, SentEmailRepository>();
builder.Services.AddScoped<ITrashedEmailRepository, TrashedEmailRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IDeletedReceivedEmailService, DeletedReceivedEmailService>();
builder.Services.AddScoped<IFavoriteReceivedEmailService, FavoriteReceivedEmailService>();
builder.Services.AddScoped<IReceivedEmailService, ReceivedEmailService>();
builder.Services.AddScoped<ISentEmailService, SentEmailService>();
builder.Services.AddScoped<ITrashedEmailService, TrashedEmailService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("f+ujXAKHk00L5jlMXo2XhAWawsOoihNP1OiAM25lLSO57+X7uBMQgwPju6yzyePi")),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

builder.Services.AddControllers();
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
