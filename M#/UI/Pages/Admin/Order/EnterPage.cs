using MSharp;

namespace Admin.Order
{
    public class EnterPage : SubPage<OrdersPage>
    {
        public EnterPage()
        {
            Add<Modules.OrderForm>();
            Add<Modules.OrderItemsList>();
        }
    }
}
