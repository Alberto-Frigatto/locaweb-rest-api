using Microsoft.EntityFrameworkCore;
using locaweb_rest_api.Data.Contexts;
using locaweb_rest_api.Services;
using locaweb_rest_api.Services.Impl;
using locaweb_rest_api.Repositories;
using locaweb_rest_api.Repositories.Impl;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(
    opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
);

builder.Services.AddScoped<IDeletedReceivedEmailRepository, DeletedReceivedEmailRepository>();
builder.Services.AddScoped<IFavoriteReceivedEmailRepository, FavoriteReceivedEmailRepository>();
builder.Services.AddScoped<IReceivedEmailRepository, ReceivedEmailRepository>();
builder.Services.AddScoped<ISentEmailRepository, SentEmailRepository>();
builder.Services.AddScoped<ITrashedEmailRepository, TrashedEmailRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IDeletedReceivedEmailService, DeletedReceivedEmailService>();
builder.Services.AddScoped<IFavoriteReceivedEmailService, FavoriteReceivedEmailService>();
builder.Services.AddScoped<IDeletedReceivedEmailService, DeletedReceivedEmailService>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
