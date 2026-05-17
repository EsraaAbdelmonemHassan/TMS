namespace TMS.Tests
{
    using System;
    using System.Threading.Tasks;
    using Domain;
    using Olive;
    using Olive.Entities;
    using Xunit;

    public class ProductValidationTests
    {
        [Fact]
        public async Task Validate_throws_when_price_out_of_range()
        {
            var product = new Product
            {
                Name = "Test",
                Code = "T1",
                Price = 15000,
                Quantity = 1
            };

            var ex = await Assert.ThrowsAsync<ValidationException>(() => product.Validate());
            Assert.Contains("10000", ex.Message);
        }

        [Fact]
        public async Task Validate_throws_when_end_before_start()
        {
            var product = new Product
            {
                Name = "Test",
                Code = "T2",
                Price = 10,
                Quantity = 1,
                AvailableFrom = DateTime.Today,
                AvailableTo = DateTime.Today.AddDays(-1)
            };

            await Assert.ThrowsAsync<ValidationException>(() => product.Validate());
        }

        [Fact]
        public async Task Validate_throws_for_invalid_manual_extension()
        {
            var product = new Product
            {
                Name = "Test",
                Code = "T3",
                Price = 10,
                Quantity = 1,
                Manual = "file.exe"
            };

            await Assert.ThrowsAsync<ValidationException>(() => product.Validate());
        }
    }
}
