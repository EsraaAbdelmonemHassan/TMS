namespace TMS.Tests
{
    using System.Threading.Tasks;
    using Domain;
    using Olive.Entities;
    using Xunit;

    public class OrderItemValidationTests
    {
        [Fact]
        public async Task Validate_throws_when_quantity_not_positive()
        {
            var item = new OrderItem { Quantity = 0, UnitPrice = 10 };

            await Assert.ThrowsAsync<ValidationException>(() => item.Validate());
        }

        [Fact]
        public async Task LineTotal_multiplies_quantity_and_unit_price()
        {
            var item = new OrderItem { Quantity = 4, UnitPrice = 12.5m };
            Assert.Equal(50m, item.LineTotal);
        }
    }
}
