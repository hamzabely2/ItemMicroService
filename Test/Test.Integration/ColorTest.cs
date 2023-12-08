using Context.Interface;
using Entity.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Model.DetailsItem;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Test.Common;
using Xunit;


namespace Api.Test.Integration
{
    public class ColorTest : TestBase, IClassFixture<WebApplicationFactory<Program>>, IDisposable
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;
        protected readonly ItemMicroServiceIDbContext _context;
        protected readonly IConfiguration _configuration;

        public ColorTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.UseEnvironment("Test");
            });

            _context = _factory.Services.GetService<ItemMicroServiceIDbContext>();

            _client = _factory.CreateClient();

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        public string GenerateJwtTokenForUser(ClaimsPrincipal user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9"); // Changez ceci avec votre clé secrète réelle
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = user.Identity as ClaimsIdentity,
                Expires = DateTime.UtcNow.AddHours(1),
                Audience = "http://localhost:7269",
                Issuer = "http://localhost:8080",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }



        [Fact]
        public async Task GetAllColors_ReturnAllColors()
        {

            _context.CreateColor();

            // Arrange
            var response = await _client.GetAsync("/api/color");

            // Assert
            response.EnsureSuccessStatusCode();

            var colors = await response.Content.ReadFromJsonAsync<List<ColorDto>>();

            // Assertions sur la liste retournée
            Assert.NotNull(colors);
            Assert.NotEmpty(colors);

        }

        [Fact]
        public async Task CreateColor_ReturnColor()
        {
            _context.CreateColor();

            var newItem = new ColorDto { Label = "Red" };
            var newItemJson = new StringContent(JsonSerializer.Serialize(newItem), Encoding.UTF8, "application/json");

            var adminUser = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
        {
            new Claim(ClaimTypes.Name, "admin_username"),
            new Claim(ClaimTypes.Role, RoleString.Admin)
        }, "test"));
            var token = GenerateJwtTokenForUser(adminUser);

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {token}");

            var response = await _client.PostAsync("/api/color/create", newItemJson);

            response.EnsureSuccessStatusCode();

            var createdColor = await response.Content.ReadFromJsonAsync<ColorDto>();
            Assert.NotNull(createdColor);
        }


        [Fact]
        public async Task DelteColor_ReturnColor()
        {
            _context.CreateColor();


            var adminUser = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
        {
            new Claim(ClaimTypes.Name, "admin_username"),
            new Claim(ClaimTypes.Role, RoleString.Admin)
        }, "test"));
            var token = GenerateJwtTokenForUser(adminUser);

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {token}");

            int colorId = 1;
            var response = await _client.DeleteAsync($"/api/color/delete/{colorId}");

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
