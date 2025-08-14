using Moq;
using ProductApi.Data.Repositories;
using ProductApi.DTOs;
using ProductApi.Entities;
using ProductApi.Services;
using System.Threading.Tasks;
using Xunit;

namespace ProductApi.Tests
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly ProductService _service;

        public ProductServiceTests()
        {

            _mockRepo = new Mock<IProductRepository>();
            _service = new ProductService(_mockRepo.Object);
        }

        [Fact]
        public async Task CreateProductAsync_ShouldCallAddAsync_AndReturnProduct()
        {
            // Arrange
            var productDto = new CreateProductDTO
            {
                Name = "Mouse Gamer",
                Price = 150.00m,
                Category = "Periféricos"
            };

            _mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Product>()))
                     .Returns(Task.CompletedTask);


            var result = await _service.CreateProductAsync(productDto);

  
            _mockRepo.Verify(repo => repo.AddAsync(It.IsAny<Product>()), Times.Once);

            Assert.NotNull(result);
            Assert.Equal(productDto.Name, result.Name);
            Assert.Equal(productDto.Price, result.Price);
        }
    }
}