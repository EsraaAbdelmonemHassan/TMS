namespace Domain
{
    using System;
    using System.Threading.Tasks;
    using Olive;
    using Olive.Entities;

    public static class OrderMaintenance
    {
        public static async Task MarkExpiredAsync()
        {
            var database = Context.Current.Database();
            var expired = await database.Of<Order>()
                .Where(x => x.EndDate != null && x.EndDate < DateTime.Today && x.Status != "Expired")
                .GetList();

            foreach (var order in expired)
            {
                await database.Update(order, o => o.Status = "Expired");
            }
        }
    }
}
