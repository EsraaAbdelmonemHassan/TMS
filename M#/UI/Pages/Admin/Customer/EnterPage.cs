using MSharp;

namespace Admin.Customer
{
    public class EnterPage : SubPage<CustomersPage>
    {
        public EnterPage()
        {
            Add<Modules.CustomerForm>();
        }
    }
}
