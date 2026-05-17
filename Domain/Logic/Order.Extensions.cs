namespace Domain
{
    using System.Linq;
    using System.Threading.Tasks;
    using Olive.Entities;

    partial class Order
    {
        public async Task RecalculateTotalAsync()
        {
            var items = await Database.Of<OrderItem>()
                .Where(x => x.OrderId == ID)
                .GetList();

            TotalAmount = items.Sum(x => x.Quantity * x.UnitPrice);
            await Database.Update(this, o => o.TotalAmount = TotalAmount);
        }
    }
}
