namespace TMS.Tests
{
    using System;
    using Domain;
    using Xunit;

    public class OrderValidationTests
    {
        [Fact]
        public void IsExpired_true_when_end_date_before_today()
        {
            var order = new Order { EndDate = DateTime.Today.AddDays(-2) };
            Assert.True(order.IsExpired());
        }

        [Fact]
        public void IsExpired_false_when_end_date_not_set()
        {
            var order = new Order();
            Assert.False(order.IsExpired());
        }
    }
}
