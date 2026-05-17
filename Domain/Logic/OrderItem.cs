namespace Domain
{
    using System.Threading.Tasks;
    using Olive;
    using Olive.Entities;

    partial class OrderItem
    {
        public bool IsOrderApproved => Order?.IsApproved == true;

        public decimal LineTotal => Quantity * UnitPrice;

        public override async Task Validate()
        {
            if (UnitPrice == 0 && ProductId != null)
            {
                var product = await Database.GetOrDefault<Product>(ProductId);
                if (product != null)
                    UnitPrice = product.Price;
            }

            if (Quantity <= 0)
                throw new ValidationException("Quantity must be greater than zero.");

            if (UnitPrice < 0 || UnitPrice > 10000)
                throw new ValidationException("Unit price is outside the allowed range.");

            await base.Validate();
        }

        protected override async Task OnSaved(SaveEventArgs e)
        {
            await base.OnSaved(e);

            if (OrderId != null)
            {
                var order = await Database.GetOrDefault<Order>(OrderId);
                if (order != null)
                    await order.RecalculateTotalAsync();
            }
        }
    }
}
