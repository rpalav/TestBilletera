using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using BilleteraAPI.Application.Dtos;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace BilleteraAPI.IntegrationTests
{
    public class BilleteraControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public BilleteraControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task AddBilleteraAsync_ReturnsOk()
        {
            var billeteraDto = new BilleteraDto
            {
                DocumentId = "123456",
                Name = "Juan Perez",
                Balance = 1000
            };

            var response = await _client.PostAsJsonAsync("/api/Billeteras", billeteraDto);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetAllBilleterasAsync_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/Billeteras/Billeteras");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetBilleteraByIdAsync_ReturnsOk()
        {
            int idBilletera = 1;

            var response = await _client.GetAsync($"/api/Billeteras/Billeteras/{idBilletera}");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task UpdateBilleteraAsync_ReturnsOk()
        {
            int idBilletera = 1;
            var billeteraDto = new BilleteraDto
            {
                DocumentId = "123456",
                Name = "Juan Perez",
                Balance = 1000
            };

            var response = await _client.PutAsJsonAsync($"/api/Billeteras/Billeteras/{idBilletera}", billeteraDto);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task DeleteBilleteraAsync_ReturnsOk()
        {
            int idBilletera = 1;

            var response = await _client.DeleteAsync($"/api/Billeteras/Billeteras/{idBilletera}");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
