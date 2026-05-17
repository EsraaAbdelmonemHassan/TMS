using MSharp;

namespace Admin
{
    public class ProductsPage : SubPage<AdminPage>
    {
        public ProductsPage()
        {
            Add<Modules.ProductsList>();
        }
    }
}
