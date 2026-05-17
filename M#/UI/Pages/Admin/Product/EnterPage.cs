using MSharp;

namespace Admin.Product
{
    public class EnterPage : SubPage<ProductsPage>
    {
        public EnterPage()
        {
            Layout(Layouts.AdminDefaultModal);
            Add<Modules.ProductForm>();
        }
    }
}
