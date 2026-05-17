using MSharp;

namespace Admin
{
    public class OrdersPage : SubPage<AdminPage>
    {
        public OrdersPage()
        {
            Add<Modules.OrdersList>();
        }
    }
}
