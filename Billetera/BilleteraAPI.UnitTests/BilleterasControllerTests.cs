using BilleteraAPI.Application.Commands;
using BilleteraAPI.Application.Dtos;
using BilleteraAPI.Application.Queries;
using BilleteraAPI.Domain.Entities;
using BilleteraAPI.WebApi.Controllers;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BilleteraAPI.UnitTests
{
    public class BilleterasControllerTests
    {
        private readonly Mock<ISender> _senderMock;
        private readonly BilleterasController _controller;

        public BilleterasControllerTests()
        {
            _senderMock = new Mock<ISender>();
            _controller = new BilleterasController(_senderMock.Object);
        }

        [Fact]
        public async Task AddBilleteraAsync_ReturnsOkResult()
        {
            var billeteraDto = new BilleteraDto
            {
                DocumentId = "123456",
                Name = "Juan Perez",
                Balance = 1000
            };

            var billeteraEntity = new BilleteraEntity
            {
                Id = 1,
                DocumentId = billeteraDto.DocumentId,
                Name = billeteraDto.Name,
                Balance = billeteraDto.Balance,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _senderMock.Setup(s => s.Send(It.IsAny<AddBilleteraCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(billeteraEntity);

            var result = await _controller.AddBilleteraAsync(billeteraDto);

            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo(billeteraEntity);
        }

        [Fact]
        public async Task GetAllBilleterasAsync_ReturnsOkResult()
        {
            _senderMock.Setup(s => s.Send(It.IsAny<GetAllBilleteraQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<BilleteraDto>());

            var result = await _controller.GetAllBilleterasAsync();

            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task GetBilleteraByIdAsync_ReturnsOkResult()
        {
            int idBilletera = 1;
            _senderMock.Setup(s => s.Send(It.IsAny<GetAllBilleteraByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BilleteraDto());

            var result = await _controller.GetBilleteraByIdAsync(idBilletera);

            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task UpdateBilleteraAsync_ReturnsOkResult()
        {
            int idBilletera = 1;
            var billeteraDto = new BilleteraDto
            {
                DocumentId = "123456",
                Name = "Juan Perez",
                Balance = 2000
            };

            var billeteraEntity = new BilleteraEntity
            {
                Id = idBilletera,
                DocumentId = billeteraDto.DocumentId,
                Name = billeteraDto.Name,
                Balance = billeteraDto.Balance,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _senderMock.Setup(s => s.Send(It.IsAny<UpdateBilleteraCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(billeteraEntity);

            var result = await _controller.UpdateBilleteraAsync(idBilletera, billeteraDto);

            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo(billeteraEntity);
        }

        [Fact]
        public async Task DeleteBilleteraAsync_ReturnsOkResult()
        {
            // Arrange
            int idBilletera = 1;
            _senderMock.Setup(s => s.Send(It.IsAny<DeleteBilleteraCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteBilleteraAsync(idBilletera);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
        }
    }

}
