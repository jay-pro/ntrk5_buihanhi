using AutoMapper;
using ecommerceweb.API.Controllers;
using ecommerceweb.API.Interfaces;
using ecommerceweb.API.Models;
using ecommerceweb.API.Profiles;
using ecommerceweb.SharedModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ecommerceweb.Test
{
    public class APIProductControllerTest
    {
        private IMapper _mapper;

        /*public void APIProductControllerTest()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductProfile());
            });
            _mapper = mockMapper.CreateMapper();
        }*/

        [Fact]
        public async Task GetProducts()//Return Ok if success
        {

            // Arrange
            var products = new List<Product>
            {
                new Product{ProductId =1, ProductName = "Kiwi 1kg", CategoryId = 1},
                new Product{ProductId =2, ProductName = "Strawberry 1kg", CategoryId = 1},
                new Product{ProductId =5, ProductName = "dragonfruit 2", CategoryId = 1},
            };

            var returnProductDTOs = new List<ProductDTO>
            {
                new ProductDTO{ProductId =1, ProductName = "Kiwi 1kg", CategoryId = 1},
                new ProductDTO{ProductId =2, ProductName = "Strawberry 1kg", CategoryId = 1},
                new ProductDTO{ProductId =5, ProductName = "dragonfruit 2", CategoryId = 1},
            };

            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(s => s.GetAsync()).Returns(Task.FromResult(products));

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(s => s.Map<List<ProductDTO>>(products)).Returns(returnProductDTOs);

            var controller = new ProductsController(productRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = (await controller.GetProducts()) as OkObjectResult;

            // Assert
            Assert.NotNull(result);

            var data = result.Value as IEnumerable<ProductDTO>;
            Assert.NotNull(data);
            Assert.Equal(returnProductDTOs, data);
        }


    }
}