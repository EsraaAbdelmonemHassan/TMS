using MSharp;

namespace Admin.Product
{
    public class ViewPage : SubPage<ProductsPage>
    {
        public ViewPage()
        {
            Add<Modules.ProductView>();
        }
    }
}
