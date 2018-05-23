using Microsoft.AspNetCore.Mvc;
using System;
using app.Controllers;
using app.Models;
using app.Services;
using Moq;
using Xunit;

namespace tests.Controllers {
    public class PedidoControllerTest {
        protected PedidoController ControllerUnderTest { get; }
        protected Mock<IPedidoService> PedidoServiceMock { get; }

        public PedidoControllerTest () {
            PedidoServiceMock = new Mock<IPedidoService> ();
            ControllerUnderTest = new PedidoController (PedidoServiceMock.Object);
        }

        public class ReadAllAsync : PedidoControllerTest {
            [Fact]
            public async void Should_return_OkObjectResult_with_clans () {
                // Arrange
                var expectedPedidos = new Pedido[] {
                    new Pedido { Id = new Guid (), DataCriacao = DateTime.Now },
                    new Pedido { Id = new Guid (), DataCriacao = DateTime.Now },
                    new Pedido { Id = new Guid (), DataCriacao = DateTime.Now }
                };
                PedidoServiceMock
                    .Setup (x => x.ReadAllAsync ())
                    .ReturnsAsync (expectedPedidos); // Mocked the ReadAllAsync() method

                // Act
                var result = await ControllerUnderTest.ReadAllAsync ();

                // Assert
                var okResult = Assert.IsType<OkObjectResult> (result);
                Assert.Same (expectedPedidos, okResult.Value);
            }
        }

        public class CreateAsync : PedidoControllerTest{
            [Fact]
            public async void Should_return_OkObjectResult_with_pedido_created(){
                // Arrange

                // Act
                var result = await ControllerUnderTest.CreateAsync();

                // Assert
                var okResult = Assert.IsType<OkObjectResult> (result);
                Assert.IsType<Pedido>(okResult.Value);
            }
        }
    }
}