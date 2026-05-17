namespace TMS.Tests
{
    using System;
    using Domain;
    using Xunit;

    public class ProductEntityTests
    {
        [Fact]
        public void Product_entity_can_be_created_with_required_fields()
        {
            var product = new Product
            {
                Name = "Test Product",
                Code = "P001",
                Price = 99.99m,
                Quantity = 10
            };

            Assert.Equal("Test Product", product.Name);
            Assert.Equal("P001", product.Code);
        }

        [Fact]
        public void IsExpired_returns_true_when_available_to_is_in_past()
        {
            var product = new Product
            {
                Name = "Expired",
                Code = "E1",
                AvailableTo = DateTime.Today.AddDays(-1)
            };

            Assert.True(product.IsExpired());
        }

        [Fact]
        public void IsExpired_returns_false_when_no_end_date()
        {
            var product = new Product { Name = "Active", Code = "A1" };
            Assert.False(product.IsExpired());
        }
    }
}
