using System;
using Xunit;
using ProjectDemoPage.Controllers;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace ProjectDemoPageTests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_Default_ReturnsViewResult()
        {
            // Arrange
            var stubLogger = new Mock<ILogger<HomeController>>();
            var homeController = new HomeController(stubLogger.Object);

            // Act
            var result = homeController.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Privacy_Default_ReturnsViewResult()
        {
            // Arrange
            var stubLogger = new Mock<ILogger<HomeController>>();
            var homeController = new HomeController(stubLogger.Object);

            // Act
            var result = homeController.Privacy();

            // Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
