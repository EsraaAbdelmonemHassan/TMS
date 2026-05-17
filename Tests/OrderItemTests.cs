namespace TMS.Tests
{
    using Domain;
    using Xunit;

    public class OrderItemTests
    {
        [Fact]
        public void TotalPrice_is_quantity_times_unit_price()
        {
            var item = new OrderItem
            {
                Quantity = 3,
                UnitPrice = 25.50m
            };

            Assert.Equal(76.50m, item.LineTotal);
        }
    }
}
