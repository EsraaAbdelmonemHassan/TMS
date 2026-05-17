using MSharp;

namespace Admin.Order.OrderItem
{
    public class EnterPage : SubPage<Admin.Order.EnterPage>
    {
        public EnterPage()
        {
            Layout(Layouts.AdminDefaultModal);
            Add<Modules.OrderItemForm>();
        }
    }
}
