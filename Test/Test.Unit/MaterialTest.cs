using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Repository.Interface;
using Test.Common;

namespace Api.Test.Unit
{
    public class MaterialTest : TestBase
    {
        private MaterialIRepository _materalRepository;



        [SetUp]
        public void SetUp()
        {
            SetUpTest();

            _materalRepository = _serviceProvider?.GetService<MaterialIRepository>();
            _context.CreateMaterial();
        }

        [TearDown]
        public void TearDown()
        {
            CleanTest();
        }

        [Test]
        public async Task GetMaterial()
        {
            // Arrange
            var materialId = 1;

            // Act
            var material = await _materalRepository.GetByKeys(materialId).ConfigureAwait(false);

            // Assert
            Assert.That(material, Is.Not.Null);
            Assert.That(material.Id, Is.EqualTo(materialId));
        }


        [Test]
        public async Task DeleteMaterial()
        {
            // Arrange
            var materialId = 2;

            var material = await _materalRepository.GetByKeys(materialId).ConfigureAwait(false);
            // Act
            var materialDelete = await _materalRepository.DeleteElementAsync(material).ConfigureAwait(false);

            // Assert
            Assert.That(materialDelete, Is.Not.Null);
            Assert.That(materialDelete.Id, Is.EqualTo(materialId));
        }
    }
}

