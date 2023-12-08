using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Repository.Interface;
using Test.Common;

namespace Api.Test.Unit
{
    public class ColorTest : TestBase
    {
        private ColorIRepository _colorRepository;



        [SetUp]
        public void SetUp()
        {
            SetUpTest();

            _colorRepository = _serviceProvider?.GetService<ColorIRepository>();
            _context.CreateColor();
        }

        [TearDown]
        public void TearDown()
        {
            CleanTest();
        }

        [Test]
        public async Task GetColor()
        {
            // Arrange
            var colorId = 1;

            // Act
            var color = await _colorRepository.GetByKeys(colorId).ConfigureAwait(false);

            // Assert
            Assert.That(color, Is.Not.Null);
            Assert.That(color.Id, Is.EqualTo(colorId));
        }


        [Test]
        public async Task DeleteColor()
        {
            // Arrange
            var colorId = 2;

            var color = await _colorRepository.GetByKeys(colorId).ConfigureAwait(false);
            // Act
            var colorDelete = await _colorRepository.DeleteElementAsync(color).ConfigureAwait(false);

            // Assert
            Assert.That(colorDelete, Is.Not.Null);
            Assert.That(colorDelete.Id, Is.EqualTo(colorId));
        }
    }
}
