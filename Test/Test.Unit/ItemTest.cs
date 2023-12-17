using Entity.Model;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Repository.Interface;
using Test.Common;

namespace Api.Test.Unit
{
    [TestFixture]

    public class ItemTest : TestBase
    {
        private IItemRepository _itemRepository;

        //private IServiceItem _itemService;

        [SetUp]
        public void SetUp()
        {
            SetUpTest();

            _itemRepository = _serviceProvider?.GetService<IItemRepository>();
            //_itemService = _serviceProvider?.GetService<IServiceItem>();

            _context.CreateItem();
        }

        [TearDown]
        public void TearDown()
        {
            CleanTest();
        }

        [Test]
        public async Task GetItem()
        {
            // Arrange
            var itemId = 2;

            // Act
            var item = await _itemRepository.GetByKeys(itemId).ConfigureAwait(false);

            // Assert
            Assert.That(item, Is.Not.Null);
            Assert.That(item.Id, Is.EqualTo(itemId));

        }

        [Test]
        public async Task AddItem()
        {
            // Arrange
            var item = new Item()
            {
                Id = 3,
                Name = "vase",
                Price = 20,
                CategoryId = 1,
                ColorId = 1,
                MaterialId = 1,
                Stock = true,
                Description = "description",
            };
            // Act
            var addItem = await _itemRepository.CreateElementAsync(item).ConfigureAwait(false);
            var itemExists = await _itemRepository.GetByKeys(item.Id).ConfigureAwait(false);

            // Assert
            Assert.That(addItem, Is.Not.Null);
            Assert.That(itemExists, Is.Not.Null);
            // Check that itemExists is not null before accessing its properties
            if (itemExists != null)
            {
                Assert.That(itemExists.Id, Is.EqualTo(item.Id));
            }
        }

        [Test]
        public async Task UpdateItem()
        {
            // Arrange
            var itemId = 2;
            var updatedDescription = "description update";

            // Act
            var item = await _itemRepository.GetByKeys(itemId).ConfigureAwait(false);

            //Arange update
            item.Description = updatedDescription;

            var itemUpdate = await _itemRepository.UpdateElementAsync(item).ConfigureAwait(false);

            // Assert
            Assert.That(itemUpdate, Is.Not.Null);
            Assert.That(itemUpdate.Id, Is.EqualTo(itemId));
            Assert.That(itemUpdate.Description, Is.EqualTo(updatedDescription));
        }


        [Test]
        public async Task DeleteItem()
        {
            // Arrange
            var itemId = 2;
            // Act
            var item = await _itemRepository.GetByKeys(itemId).ConfigureAwait(false);
            var itemDelete = await _itemRepository.DeleteElementAsync(item).ConfigureAwait(false);

            // Assert
            Assert.That(itemDelete, Is.Not.Null);
            Assert.That(itemDelete.Id, Is.EqualTo(itemId));
        }






    }
}
