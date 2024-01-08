using Lab2_3Web.Controllers;
using Lab2_3Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Services.Stories.MainStories;
using Services.Stories.PurchaseStories;

namespace Tests
{
    public class HomeControllerTests
    {
        private Mock<IMediator> _mediatorMock = new Mock<IMediator>();
        private Mock<ILogger<HomeController>> _loggerMock = new Mock<ILogger<HomeController>>();
        private TestHelper _testHelper = new TestHelper();


        [Theory]
        [InlineData("")]
        public async Task Index_ReturnsAViewResult_WithAListProducts(string promo)
        {
            _mediatorMock.Setup(x => x.Send(It.IsAny<ShowProductsByPromocodeStory>(), default(CancellationToken)))
                     .ReturnsAsync(_testHelper.TestProducts);

            var controller = new HomeController(_loggerMock.Object, _mediatorMock.Object);
            var result = await controller.Index(promo);

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<ProductViewModel>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Theory]
        [InlineData(2)]
        public async Task BuyGet_ReturnsAViewResult_WithProductId(int id)
        {
            var controller = new HomeController(_loggerMock.Object, _mediatorMock.Object);

            // Act
            var result = await controller.Buy(id);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<int>(
                viewResult.ViewData["ProductId"]);
            Assert.Equal(id, model);
        }

        [Fact]
        public async Task BuyPost_ReturnBadRequestResult_WhenModelStateIsInvalid()
        {
            // Arrange

            _mediatorMock.Setup(x => x.Send(It.IsAny<ShowProductsByPromocodeStory>(), default(CancellationToken)))
                     .ReturnsAsync(_testHelper.TestProducts);

            var controller = new HomeController(_loggerMock.Object, _mediatorMock.Object);
            controller.ModelState.AddModelError("Address", "Required");

            var purchase = new PurchaseViewModel()
            {
                Person = "Test",
            };

            // Act
            var result = await controller.Buy(purchase);


            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public async Task BuyPost_ReturnARedirectAndAddPurchase_WhenModelStateIsValid()
        {
            // Arrange
            _mediatorMock.Setup(x => x.Send(It.IsAny<CreatePurchaseStory>(), default(CancellationToken)))
                     .Verifiable();

            var controller = new HomeController(_loggerMock.Object, _mediatorMock.Object);

            var purchase = new PurchaseViewModel()
            {
                Person = "Тест",
                Address = "Улица"
            };

            // Act
            var result = await controller.Buy(purchase);


            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            _mediatorMock.Verify();
        }

    }
}