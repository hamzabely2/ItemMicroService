using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Repository.Interface;
using Test.Common;

namespace Api.Test.Unit
{
    public class CategoryTest : TestBase
    {
        private CategoryIRepository _categoryRepository;


        [SetUp]
        public void SetUp()
        {
            SetUpTest();

            _categoryRepository = _serviceProvider?.GetService<CategoryIRepository>();
            _context.CreateCategory();
        }

        [TearDown]
        public void TearDown()
        {
            CleanTest();
        }

        [Test]
        public async Task GetCategory()
        {
            // Arrange
            var categoryId = 1;

            // Act
            var category = await _categoryRepository.GetByKeys(categoryId).ConfigureAwait(false);

            // Assert
            Assert.That(category, Is.Not.Null);
            Assert.That(category.Id, Is.EqualTo(categoryId));
        }


        [Test]
        public async Task DeleteCategory()
        {
            // Arrange
            var categoryId = 2;

            var category = await _categoryRepository.GetByKeys(categoryId).ConfigureAwait(false);
            // Act
            var categoryDelete = await _categoryRepository.DeleteElementAsync(category).ConfigureAwait(false);

            // Assert
            Assert.That(categoryDelete, Is.Not.Null);
            Assert.That(categoryDelete.Id, Is.EqualTo(categoryId));
        }
    }
}
