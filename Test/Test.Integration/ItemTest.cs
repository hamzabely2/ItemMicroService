using Context.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Test.Common;
using Xunit;

namespace Test.Integration
{
    public class ItemTest : IClassFixture<WebApplicationFactory<Program>>, IDisposable
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;
        protected readonly ItemMicroServiceIDbContext _context;
        protected readonly IConfiguration _configuration;

        public ItemTest(WebApplicationFactory<Program> factory)
        {

            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.UseEnvironment("Test");
            });

            _context = _factory.Services.GetService<ItemMicroServiceIDbContext>();

            _client = _factory.CreateClient();

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _context.CreateItem();

        }


        [Fact]
        public async Task GetAllItem_ReturnAllItems()
        {
            // Arrange
            var response = await _client.GetAsync("/api/item");

            // Assert
            response.EnsureSuccessStatusCode();

            var items = response;

            // Assertions sur la liste retournée
            Assert.NotNull(items);
            //Assert.NotEmpty(items);

        }


        [Fact]
        public async Task GetItem_ReturnItems()
        {


            // Arrange
            var response = await _client.GetAsync("/api/item/1");

            // Assert
            //response.EnsureSuccessStatusCode();

            var items = response;

            // Assertions sur la liste retournée
            Assert.NotNull(items);
            //Assert.NotEmpty(items);

        }
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
