using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Test
{
    public class ProductControllerTest
    {
        private readonly Mock<IRepository<Product>> _mockRepo;
        private readonly ProductsController _controller;
        private List<Product> products;

        public ProductControllerTest()
        {
            _mockRepo = new Mock<IRepository<Product>>();
            _controller = new ProductsController(_mockRepo.Object);

            products = new List<Product>
            {
                new Product { Id = 1, Name = "Kalem", Color = "Kırmızı", Price = 100, Stock = 50 },
                new Product { Id = 2, Name = "Defter", Stock =500, Color = "Mavi", Price = 200 }
            };
        }

        [Fact]
        public async Task GetProduct_ActionExecutes_ReturnOkResultWithProduct()
        {
            _mockRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(products);

            var result = await _controller.Get();

            var okResult = Assert.IsType<OkObjectResult>(result);

            var returnProduct = Assert.IsAssignableFrom<IEnumerable<Product>>(okResult.Value);

            Assert.Equal<int>(2, returnProduct.ToList().Count);
        }

        [Theory]
        [InlineData(0)]
        public async Task GetProduct_IdInvalid_ReturnNotFound(int productId)
        {
            Product product = null;

            _mockRepo.Setup(x => x.GetByIdAsync(productId)).ReturnsAsync(product);

            var result = await _controller.Get(productId);

            Assert.IsType<NotFoundResult>(result); // NotFound(XXX) içerisinde data dönüyor olursa NotFoundObjectResult kullanmak lazım
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task GetProduct_IdValid_ReturnOkResult(int productId)
        {
            var product = products.FirstOrDefault(x => x.Id == productId);

            _mockRepo.Setup(x => x.GetByIdAsync(productId)).ReturnsAsync(product);

            var result = await _controller.Get(productId);

            var okResult = Assert.IsType<OkObjectResult>(result);

            var returnProduct = Assert.IsType<Product>(okResult.Value);

            Assert.Equal(productId, returnProduct.Id);

            Assert.Equal(product.Name, returnProduct.Name);
        }

        [Theory]
        [InlineData(1)]
        public async Task PutProduct_IdIsNotEqualProduct_ReturnBadRequstResult(int productId)
        {
            var product = products.FirstOrDefault(x => x.Id == productId);

            var result = await _controller.Put(2, product);

            Assert.IsType<BadRequestResult>(result);
        }


        [Theory]
        [InlineData(1)]
        public async Task PutProduct_ActionExecutes_ReturnNoContent(int productId)
        {
            var product = products.FirstOrDefault(x => x.Id == productId);

            _mockRepo.Setup(x => x.Update(product));

            var result = await _controller.Put(productId, product);

            _mockRepo.Verify(x => x.Update(product), Times.Once);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task PostProduct_ActionExecutes_ReturnOk()
        {
            var product = products.First();

            _mockRepo.Setup(x => x.CreateAsync(product)).Returns(Task.CompletedTask);

            var result = await _controller.Post(product);

            _mockRepo.Verify(x => x.CreateAsync(product), Times.Once);

            Assert.IsType<OkObjectResult>(result);
        }

        [Theory]
        [InlineData(0)]
        public async Task DeleteProduct_IdInvalid_ReturnNotfound(int productId)
        {
            Product product = null;

            _mockRepo.Setup(x => x.GetByIdAsync(productId)).ReturnsAsync(product);

            var result = await _controller.Delete(productId);

            Assert.IsType<NotFoundResult>(result);
        }

        [Theory]
        [InlineData(1)]
        public async Task DeleteProduct_ActionExecute_ReturnNoContent(int productId)
        {
            var product = products.First(x => x.Id == productId);

            _mockRepo.Setup(x => x.GetByIdAsync(productId)).ReturnsAsync(product);

            _mockRepo.Setup(x => x.Delete(product));

            var result = await _controller.Delete(productId);

            _mockRepo.Verify(x => x.Delete(product), Times.Once);

            Assert.IsType<NoContentResult>(result);

        }
    }
}
