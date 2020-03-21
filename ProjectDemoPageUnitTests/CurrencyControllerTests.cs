using Xunit;
using System;
using ProjectDemoPage.Controllers;
using Moq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectDemoPage.Models;

namespace ProjectDemoPageTests
{
    public class CurrencyControllerTests
    {
        [Fact]
        public void Converter_GetRequest_ReturnsTypeViewResult()
        {
            // Arrange
            var fakeCurrencyController = CurrencyControllerFactory();
            
            // Act
            var result = fakeCurrencyController.Converter();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Converter_HttpPostRequest_ReturnsTypeViewResult()
        {
            // Arrange
            var fakeCurrencyController = CurrencyControllerFactory();
            var stubCurrencyModel = new Mock<CurrencyConverterModel>().SetupAllProperties();
            
            // Act
            var result = fakeCurrencyController.Converter(stubCurrencyModel.Object);

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Converter_HttpPostRequestInvalidInputModel_ReturnsInputModel()
        {
            // Arrange
            var fakeCurrencyController = CurrencyControllerFactory();
            var stubCurrencyModel = new CurrencyConverterModel
            {
                CurrencyFrom = "TEST",
            };

            
            // Act
            var result = fakeCurrencyController.Converter(stubCurrencyModel);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<CurrencyConverterModel>(viewResult.ViewData.Model);
            Assert.Contains("TEST", model.CurrencyFrom);
        }

        private CurrencyController CurrencyControllerFactory()
        {
            var stubHttpClientFactory = new Mock<IHttpClientFactory>().SetupAllProperties();
            return new CurrencyController(stubHttpClientFactory.Object);
        }
    }
}