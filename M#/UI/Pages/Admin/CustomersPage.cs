using MSharp;

namespace Admin
{
    public class CustomersPage : SubPage<AdminPage>
    {
        public CustomersPage()
        {
            Add<Modules.CustomersList>();
        }
    }
}
