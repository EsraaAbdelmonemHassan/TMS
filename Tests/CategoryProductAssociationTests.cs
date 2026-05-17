namespace TMS.Tests
{
    using System;
    using Domain;
    using Xunit;

    public class CategoryProductAssociationTests
    {
        [Fact]
        public void Product_links_to_category_by_id()
        {
            var categoryId = Guid.NewGuid();
            var product = new Product
            {
                Name = "Phone",
                Code = "PH1",
                CategoryId = categoryId
            };

            Assert.Equal(categoryId, product.CategoryId);
        }
    }
}
