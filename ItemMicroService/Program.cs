using Ioc.Test;
using Ioc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Serilog;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

if (builder.Environment.IsEnvironment("Test"))
{
    // Configure Database connection
    builder.Services.ConfigureDBContextTest();

    // Dependency Injection
    builder.Services.ConfigureInjectionDependencyRepositoryTest();
    builder.Services.ConfigureInjectionDependencyServiceTest();
}
else
{
    // Configure Database connection
    builder.Services.ConfigureDBContext(configuration);

    // Dependency Injection
    builder.Services.ConfigureInjectionDependencyRepository();
    builder.Services.ConfigureInjectionDependencyService();
}

// Adding Authentication
var validAudience = builder.Configuration["JWT:ValidAudience"];
var validIssuer = builder.Configuration["JWT:ValidIssuer"];
var secret = builder.Configuration["JWT:Secret"];

// Log or debug these values
Log.Information($"ValidAudience: {validAudience}, ValidIssuer: {validIssuer}, Secret: {secret}");

// Set up JWT authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = validAudience,
        ValidIssuer = validIssuer,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
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

public partial class Program { }

