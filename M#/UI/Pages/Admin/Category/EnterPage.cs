using MSharp;

namespace Admin.Category
{
    public class EnterPage : SubPage<CategoriesPage>
    {
        public EnterPage()
        {
            Add<Modules.CategoryForm>();
        }
    }
}
