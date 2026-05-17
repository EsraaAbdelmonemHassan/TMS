namespace Domain
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Olive;
    using Olive.Entities;

    partial class Order
    {
        public bool IsExpired() =>
            EndDate.HasValue && EndDate.Value.Date < DateTime.Today;

        public override async Task Validate()
        {
            if (StartDate.HasValue && EndDate.HasValue && EndDate < StartDate)
                throw new ValidationException("End date must be after start date.");

            if (CustomerId != null)
            {
                var customer = await Database.GetOrDefault<Customer>(CustomerId);
                if (customer != null)
                {
                    var items = await Database.Of<OrderItem>()
                        .Where(x => x.OrderId == ID)
                        .GetList();

                    var total = items.Sum(x => x.Quantity * x.UnitPrice);
                    if (total > customer.CreditLimit)
                        throw new ValidationException("Order total exceeds the customer's credit limit.");
                }
            }

            await base.Validate();
        }

        protected override async Task OnSaved(SaveEventArgs e)
        {
            await base.OnSaved(e);

            await RecalculateTotalAsync();

            if (IsApproved && e.Mode == SaveMode.Update)
                await EmailService.SendOrderApprovedAsync(this);

            await ApplicationEventLogger.LogAsync("Order", e.Mode.ToString(), ID, Status);
        }
    }
}
