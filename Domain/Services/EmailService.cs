namespace Domain
{
    using System.Threading.Tasks;
    using Olive;
    using Olive.Entities;

    public static class EmailService
    {
        static IDatabase Database => Context.Current.Database();

        public static async Task SendOrderApprovedAsync(Order order)
        {
            var customer = await Database.GetOrDefault<Customer>(order.CustomerId);
            var name = customer?.Name ?? "Customer";
            var body = EmailTemplates.OrderApproved.Replace("{{CustomerName}}", name);
            await SendAsync(customer?.Email, "Order approved", body);
        }

        public static async Task SendWelcomeAsync(string email, string name)
        {
            var body = EmailTemplates.Welcome.Replace("{{CustomerName}}", name);
            await SendAsync(email, "Welcome", body);
        }

        static async Task SendAsync(string to, string subject, string body)
        {
            if (to.IsEmpty()) return;

            Log.For(typeof(EmailService)).Info($"Email to {to}: {subject}");
            await Task.CompletedTask;
        }
    }
}
